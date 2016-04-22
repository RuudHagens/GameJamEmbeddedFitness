using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;

public class GameManager : MonoBehaviour
{
	/// <summary>
	/// The instance.
	/// </summary>
	public static GameManager Instance;

	/// <summary>
	/// The wall object.
	/// </summary>
	public GameObject Wall_Obj;

	/// <summary>
	/// The start object.
	/// </summary>
	public GameObject Start_Obj;

	/// <summary>
	/// The end object.
	/// </summary>
	public GameObject End_Obj;

	/// <summary>
	/// The objects parent.
	/// </summary>
	public GameObject ObjectsParent;

	/// <summary>
	/// The wall parent.
	/// </summary>
	public GameObject WallParent;

	/// <summary>
	/// The canvas object.
	/// </summary>
	public Canvas Canvas_Obj;

	/// <summary>
	/// The level number.
	/// </summary>
	private int levelNumber = 0;

	/// <summary>
	/// The JSON levels.
	/// </summary>
	private string jsonLevels;
	private JSONNode levelData;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		Instance = this;

		// Get JSON data
		this.jsonLevels = File.ReadAllText(Application.dataPath + "/Scripts/gamedata.json");
		this.levelData = JSON.Parse (jsonLevels);

		StartCoroutine(this.SetLevel ());
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
	
	}

	/// <summary>
	/// Previouses the level.
	/// </summary>
	public void PreviousLevel() {
		this.levelNumber--;

		StartCoroutine(this.SetLevel ());
	}

	/// <summary>
	/// Nexts the level.
	/// </summary>
	public void NextLevel() {
		this.levelNumber++;

		StartCoroutine(this.SetLevel ());
	}

	/// <summary>
	/// Sets the level.
	/// </summary>
	public IEnumerator SetLevel() {
		yield return new WaitForSeconds (0.01f);

		// Get canvas worldpos
		Vector3 canvasWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(this.Canvas_Obj.pixelRect.size.x, this.Canvas_Obj.pixelRect.size.y, 0)) * 2;

		// Empty both parent containers
		int i, i_len = this.WallParent.transform.childCount;
		for (i = 0; i < i_len; i++) {
			GameObject.Destroy(this.WallParent.transform.GetChild(i).gameObject);
		}
		int j, j_len = this.ObjectsParent.transform.childCount;
		for (j = 0; j < j_len; j++) {
			GameObject.Destroy (this.ObjectsParent.transform.GetChild (j).gameObject);
		}

		// Get and set the level name
		string name = this.levelData["data"]["levels"][this.levelNumber]["Name"];
		HudManager.Instance.SetLevelText (name);

		// Get level time
		float time = this.levelData["data"]["levels"][this.levelNumber]["MaxTime"].AsFloat;

		// Get walls array
		JSONArray walls = this.levelData["data"]["levels"][this.levelNumber]["Walls"].AsArray;

		// Get start and end point coordinates and offsets
		Vector2 startCoords = new Vector2(this.levelData["data"]["levels"][this.levelNumber]["Start"][0][0].AsFloat, this.levelData["data"]["levels"][this.levelNumber]["Start"][0][1].AsFloat);
		Vector2 startCoordsOffset = new Vector2(this.levelData["data"]["levels"][this.levelNumber]["Start"][1][0].AsFloat, this.levelData["data"]["levels"][this.levelNumber]["Start"][1][1].AsFloat);
		Vector2 endCoords = new Vector2 (this.levelData["data"]["levels"][this.levelNumber]["End"][0][0].AsFloat, this.levelData["data"]["levels"][this.levelNumber]["End"][0][1].AsFloat);
		Vector2 endCoordsOffset = new Vector2(this.levelData["data"]["levels"][this.levelNumber]["End"][1][0].AsFloat, this.levelData["data"]["levels"][this.levelNumber]["End"][1][1].AsFloat);

		// Spawn walls
		int k, k_len = walls.Count;
		for (k = 0; k < k_len; k++) {
			// Get wall array
			JSONArray wall = walls [k].AsArray;

			// Get coordinates and offset
			Vector2 wallCoords = new Vector2(wall[0][0].AsFloat, wall[0][1].AsFloat);
			Vector2 wallCoordsOffset = new Vector2 (wall [1] [0].AsFloat, wall [1] [1].AsFloat);

			// Get wall position
			bool isWallFlipped = wall[2].AsBool;

			// Spawn wall at coordinates
			Vector3 wallPosition = new Vector3((wallCoords.x*canvasWorldPos.x) - (canvasWorldPos.x/2) + (wallCoordsOffset.x*this.Wall_Obj.GetComponent<Renderer>().bounds.size.x),
				(wallCoords.y*canvasWorldPos.y) - (canvasWorldPos.y/2) + (wallCoordsOffset.y*this.Wall_Obj.GetComponent<Renderer>().bounds.size.y));
			GameObject spawnedWall = Instantiate(this.Wall_Obj, wallPosition, Quaternion.identity) as GameObject;
			spawnedWall.transform.parent = this.WallParent.transform;
			if (isWallFlipped) {
				spawnedWall.transform.Rotate (new Vector3 (0, 0, 180));
			}
		}

		// Spawn startpoint
		Vector3 spawnedStartPosition = new Vector3((startCoords.x*canvasWorldPos.x) - (canvasWorldPos.x/2) + (startCoordsOffset.x*this.Start_Obj.GetComponent<Renderer>().bounds.size.x),
												   (startCoords.y*canvasWorldPos.y) - (canvasWorldPos.y/2) + (startCoordsOffset.y*this.Start_Obj.GetComponent<Renderer>().bounds.size.y));
		GameObject spawnedStart = Instantiate (this.Start_Obj, spawnedStartPosition, Quaternion.identity) as GameObject;
		spawnedStart.transform.parent = this.ObjectsParent.transform;

		// Spawn endpoint
		Vector3 spawnedEndPosition = new Vector3((endCoords.x*canvasWorldPos.x) - (canvasWorldPos.x/2) + (endCoordsOffset.x*this.End_Obj.GetComponent<Renderer>().bounds.size.x),
												 (endCoords.y*canvasWorldPos.y) - (canvasWorldPos.y/2) + (endCoordsOffset.y*this.End_Obj.GetComponent<Renderer>().bounds.size.y));
		GameObject spawnedEnd = Instantiate (this.End_Obj, spawnedEndPosition, Quaternion.identity) as GameObject;
		spawnedEnd.transform.parent = this.ObjectsParent.transform;
	}
}

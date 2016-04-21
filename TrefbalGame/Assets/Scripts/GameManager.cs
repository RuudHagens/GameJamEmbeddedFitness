using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	/// <summary>
	/// The wall object.
	/// </summary>
	public Sprite Wall_Obj;

	/// <summary>
	/// The level number.
	/// </summary>
	private int levelNumber = 0;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
	
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
	
	}

	/// <summary>
	/// Nexts the level.
	/// </summary>
	public void NextLevel() {
		this.levelNumber++;
	}
}

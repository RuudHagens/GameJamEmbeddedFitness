using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
	/// <summary>
	/// The instance.
	/// </summary>
	public static HudManager Instance;

	/// <summary>
	/// The level text.
	/// </summary>
	public Text LevelText;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		Instance = this;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
	
	}

	/// <summary>
	/// Sets the level text.
	/// </summary>
	/// <param name="levelName">Level name.</param>
	public void SetLevelText(string levelName) {
		this.LevelText.text = levelName;
	}

	/// <summary>
	/// Previouses the level.
	/// </summary>
	public void PreviousLevel() {
		GameManager.Instance.PreviousLevel ();
	}

	/// <summary>
	/// Nexts the level.
	/// </summary>
	public void NextLevel() {
		GameManager.Instance.NextLevel ();
	}
}

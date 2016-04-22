using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        selectThisPlayer();
    }

    void OnMouseUp()
    {
        deselectThisPlayer();
    }

    public void selectThisPlayer()
    {
        Debug.Log("Found player");
        BallManager.instance.selectThisPlayer(gameObject);
    }

    public void deselectThisPlayer()
    {
        Debug.Log("Deselect this noob player");
        BallManager.instance.selectThisPlayer(null);
    }
}

using UnityEngine;
using System.Collections;
using Assets.Scripts.helpers;

public class appleSpawner : MonoBehaviour {

    public int AppleDelay;
    private int appleTicker = 0;
    public Vector2 bottomLeft;
    public Vector2 topRight;
    public GameObject applePrefab;
    public GameObject gameWorld;//za warudo
	
	// Update is called once per frame
	void Update () {
	    if(appleTicker<=AppleDelay)
        {
            appleTicker++;
        }
        else
        {
            appleTicker = 0;
            SpawnApple();
        }
	}

    public void SpawnApple()
    {
        GameObject unit = Instantiate(applePrefab);
        unit.transform.SetParent(gameWorld.transform, false);
        unit.transform.position = RandomHelper.RandomVector2(bottomLeft, topRight);
    }
}

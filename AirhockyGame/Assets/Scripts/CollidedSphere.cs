using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollidedSphere : MonoBehaviour
{

    public GameObject sphere;
    private List<GameObject> collidedPlayers;
    private GameObject s;

    // Use this for initialization
    void Start()
    {
        collidedPlayers = new List<GameObject>();
        s = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (collidedPlayers.Count != 0 && s != null)
        {
            Vector3 playerAverageLocation = new Vector3(0, 0, 0);
            foreach (GameObject player in collidedPlayers)
            {
                playerAverageLocation += player.transform.position;
            }
            playerAverageLocation /= collidedPlayers.Count;
            s.transform.position = playerAverageLocation;
        }
    }

    /// <summary>
    /// Draws a sphere around the average position of the players
    /// </summary>
    /// <param name="players"></param>
    public GameObject spawnSphere(List<GameObject> players)
    {
        collidedPlayers = players;
        Vector3 playerAverageLocation = new Vector3(0, 0, 0);
        foreach (GameObject player in players)
        {
            playerAverageLocation += player.transform.position;
        }
        playerAverageLocation /= players.Count;

        s = (GameObject)Instantiate(sphere, playerAverageLocation, Quaternion.identity);
        s.transform.localScale *= players.Count;
        return s;
    }
}

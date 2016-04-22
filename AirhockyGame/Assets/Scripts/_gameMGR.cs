using UnityEngine;
using System.Collections.Generic;

public class _gameMGR : MonoBehaviour {


    private int scoreR;
    private int scoreB;

    void Start()
    {
        
    }

    public void AddScore(Team t)
    {
        Debug.Log("Score added for " + t);
        switch (t)//yay hacky code :DDDDD
        {
            case Team.red:
                scoreR++;
                break;
            case Team.blue:
                scoreB++;
                break;
            default:
                break;
        }
    }

    public int GetScore(Team t)
    {
        switch (t)//yay hacky code :DDDDD
        {
            case Team.red:
                return scoreR;
                break;
            case Team.blue:
                return scoreB;
                break;
            default:
                throw new UnityException();
                break;
        }
    }
}

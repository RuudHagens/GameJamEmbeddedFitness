using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.helpers;
using System;

public class _gameMGR : MonoBehaviour {


    private int scoreR;
    private int scoreB;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    private List<Player> players;
    public int MinSum;
    public int MaxSum;
    private int currAnswer;

    void Start()
    {
        players = new List<Player>();
        //hardcoded voor demo
        players.Add(p1.GetComponent<Player>());
        players.Add(p2.GetComponent<Player>());
        players.Add(p3.GetComponent<Player>());
        players.Add(p4.GetComponent<Player>());
        GenerateNewAnswer();
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
                Debug.LogError("Score added for invalid team " + t);
                break;
        }
        GenerateNewAnswer();
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
                return 0;
                Debug.LogError("Score queried for invalid team " + t);
                break;
        }
    }

    public void GenerateNewAnswer()
    {
        System.Random rA = new System.Random();
        System.Random r1 = new System.Random();
        currAnswer = rA.Next(MinSum, MaxSum);
        int eh = 0;//the # that will be given to the player
        RandomHelper.ShuffleList<Player>(players);
        int c = 0;
        foreach (Player p in players)
        {
            if(c%2==0|c==0)
            {
                eh = r1.Next(1, currAnswer);
            }
            else { eh = currAnswer - eh; }
            p.SetNumber(eh);
            c++;
        }
    }

    public int GetAnswer()
    {
        return currAnswer;
    }
}

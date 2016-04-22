using UnityEngine;
using System.Collections;
public enum Team
{
    red,
    blue
}

public class goal : MonoBehaviour {
    public Team team;
    public GameObject gameMGR;
    private _gameMGR mgr;

    void Start()
    {
        mgr = gameMGR.GetComponent<_gameMGR>();
    }

    void OnCollisionEnter(Collision col)
    {
        Team s;
        if (team == Team.red) { s = Team.blue; } else { s = Team.red; }
        if (col.gameObject.tag == "Ball")
        {
            ball b = col.gameObject.GetComponent<ball>();
            b.Reset();
            mgr.AddScore(s);
             //SendMessageUpwards("AddScore", s);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUI : MonoBehaviour {

    public GameObject gameMGR;
    public Team team;
    public Text t;
    private _gameMGR mgr;

    void Start()
    {
        mgr = gameMGR.GetComponent<_gameMGR>();
      //  t = GetComponent<Text>();
    }

    void Update()
    {
        t.text = mgr.GetScore(team).ToString();
    }
}

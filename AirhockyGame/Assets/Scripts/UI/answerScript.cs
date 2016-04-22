using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class answerScript : MonoBehaviour {
    public GameObject Gamemgr;
    private _gameMGR gamemgr;
    public Text t;

    void Start()
    {
        gamemgr = Gamemgr.GetComponent<_gameMGR>();
    }

    void Update()
    {
        t.text = gamemgr.GetAnswer().ToString();
    }
}

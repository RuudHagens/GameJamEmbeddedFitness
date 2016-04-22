using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerNumber : MonoBehaviour {


    public GameObject Player;
    private Player player;
    private Text t;
    private RectTransform rect;
	void Start () {
        player = Player.GetComponent<Player>();
        t = gameObject.GetComponent<Text>();
        rect = t.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        
        t.text = player.GetNumber().ToString();
        rect.position = new Vector3(player.transform.position.x, player.transform.position.y+5, transform.position.z);
    }

    public void SetPlayer(GameObject p)
    {
        Player = p;
        player = p.GetComponent<Player>();
    }

    public void SetPlayer(Player p)
    {
        player = p;
        Player = p.gameObject.transform.parent.gameObject;
    }
}

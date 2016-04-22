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
//        transform.position.Set(player.transform.position.x, player.transform.position.y, transform.position.z);
        rect.position = new Vector3(player.transform.position.x, player.transform.position.y+5, transform.position.z);
        Debug.Log("Playerpos "+player.transform.position.x+","+ player.transform.position.y);
        Debug.Log("Pos is now " + rect.position.x + "," + rect.position.y);
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

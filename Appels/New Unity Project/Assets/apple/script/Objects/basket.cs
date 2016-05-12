using UnityEngine;
using System.Collections;

public class basket : MonoBehaviour {

    public KeyCode kL;
    public KeyCode kR;
    public float speed;
    private Vector3 c;

    private int score;

    void Start()
    {
        c = transform.position;
    }

	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(kL))
        {
            c.x = c.x - speed;
        }
        else if(Input.GetKey(kR))
        {
            c.x = c.x + speed;
        }

        transform.position = c;
	}
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("collided with " + col);
        if (col.gameObject.tag == "pickup")
        {
            apple a = col.gameObject.GetComponent<apple>();
            a.Pickup(this);
        }
    }

    public void AddScore(int am)
    {
        score = score + am;
    }
}

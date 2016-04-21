using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {

    private Vector2 mousePosition;
    private Vector3 p;
    private Vector2 direction;
    public Camera camera;

    public float smoothTime = 0.3F;
    public float speedMultiplier;
    private Vector3 velocity = Vector3.zero;

    private bool moving = false;

    // Use this for initialization
    void Start () {
        if(speedMultiplier == 0)
        {
            speedMultiplier = 1;
        } 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !moving)
        {
            Debug.Log("Pressed left click.");

            mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            p = camera.ScreenToWorldPoint(mousePosition);
            p.z = 0;

            direction = new Vector2(p.x - transform.position.x, p.y - transform.position.y);

            /*Debug.Log("Pos Ball: " + transform.position.x + ", " + transform.position.y);
            Debug.Log("Click point: " + p);
            Debug.Log("Final Direction: " + direction);*/

            direction.Normalize();
            moving = true;
        }

        moveBall();
    }

    void moveBall()
    {
        if (moving)
        {
            /*this.transform.position = p;
            this.transform.position = p;*/

            //this.transform.position = Vector3.SmoothDamp(transform.position, p, ref velocity, smoothTime);
            transform.Translate(direction * Time.deltaTime * speedMultiplier, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Wall"))
        {
            transform.position = new Vector2(0, 0);
        }
        else
        {
            Debug.Log("Bal gevangen");    
        }
        moving = false;
    }
}

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

    private GameObject currentSelectedPlayer;
    public static BallManager instance;

    private bool movingBall = false;
    private bool movingPeople = true;

    // Use this for initialization
    void Start () {
        if(speedMultiplier == 0)
        {
            speedMultiplier = 1;
        }

        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            p = camera.ScreenToWorldPoint(mousePosition);
            p.z = 0;
        }

        if (Input.GetMouseButtonDown(0) && !movingBall)
        {
            Debug.Log("Pressed left click.");
            if (movingPeople)
            {

            }
            else
            {
                direction = new Vector2(p.x - transform.position.x, p.y - transform.position.y);

                /*Debug.Log("Pos Ball: " + transform.position.x + ", " + transform.position.y);
                Debug.Log("Click point: " + p);
                Debug.Log("Final Direction: " + direction);*/

                direction.Normalize();
                movingBall = true;
            }          
        }

        movePlayer();
        moveBall();
    }

    /// <summary>
    /// When clicked on player, that player will be the currentSelectedPlayer
    /// </summary>
    public void selectThisPlayer(GameObject obj)
    {    
        currentSelectedPlayer = obj;
    }

    void moveBall()
    {
        if (movingBall)
        {
            transform.Translate(direction * Time.deltaTime * speedMultiplier, Space.World);
        }
    }

    void movePlayer()
    {
        if (!movingBall && currentSelectedPlayer != null)
        {
            Debug.Log("Ik beweeg de speler");
            currentSelectedPlayer.transform.position = p;
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
        movingBall = false;
    }
}

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private int speed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
using UnityEngine;
using System.Collections;

public enum PlayerNumber
{
    one,
    two
}
public class Player : MonoBehaviour
{
    private int speed = 20;
    public PlayerNumber number;

    private KeyCode n;
    private KeyCode w;
    private KeyCode e;
    private KeyCode s;

    void Start()
    {
        switch (number)
        {
            case PlayerNumber.one:
                n = KeyCode.W;
                w = KeyCode.A;
                s = KeyCode.S;
                e = KeyCode.D;
                break;
            case PlayerNumber.two:
                n = KeyCode.UpArrow;
                w = KeyCode.LeftArrow;
                s = KeyCode.DownArrow;
                e = KeyCode.RightArrow;
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(n))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(s))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(w))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(e))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
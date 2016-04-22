using UnityEngine;
using System.Collections;

public enum PlayerNumber
{
    one,
    two,
    three,
    four
}
public class Player : MonoBehaviour
{
    public PlayerNumber number;
    private int speed = 20;

    private KeyCode n;
    private KeyCode w;
    private KeyCode e;
    private KeyCode s;

    private Color orignalColor;

    void Start()
    {
        orignalColor = this.GetComponent<Renderer>().material.color;

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
            case PlayerNumber.three:
                n = KeyCode.I;
                w = KeyCode.J;
                s = KeyCode.K;
                e = KeyCode.L;
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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.GetComponent<Renderer>().material.color = mixColors(orignalColor, col.gameObject.GetComponent<Player>().orignalColor);
        }
        if (col.gameObject.tag == "Ball")
        {
            Vector3 bounceDirection = new Vector3(0, 0, 0);
            if (Input.GetKey(n))
            {
                bounceDirection += new Vector3(0, 1, 0);
            }
            if (Input.GetKey(s))
            {
                bounceDirection += new Vector3(0, -1, 0);
            }
            if (Input.GetKey(w))
            {
                bounceDirection += new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(e))
            {
                bounceDirection += new Vector3(1, 0, 0);
            }
            bounceDirection.Normalize();
            bounceDirection *= 20;
            col.gameObject.GetComponent<Rigidbody>().AddForce(bounceDirection, ForceMode.Impulse);
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.GetComponent<Renderer>().material.color = orignalColor;
            col.gameObject.GetComponent<Renderer>().material.color = col.gameObject.GetComponent<Player>().orignalColor;
        }
    }

    public Color mixColors(Color p1Color, Color p2Color)
    {
        Color result = new Color(0, 0, 0, 0);
        result += p1Color;
        result += p2Color;
        result /= 2;
        return result;
    }
}
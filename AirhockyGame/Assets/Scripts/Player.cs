using UnityEngine;
using System.Collections;

public enum PlayerNumber
{
    one,
    two
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
            Debug.Log("I feel triggered");
            this.GetComponent<Renderer>().material.color = mixColors(orignalColor, col.gameObject.GetComponent<Player>().orignalColor);
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
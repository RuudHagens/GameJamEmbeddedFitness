using UnityEngine;
using System.Collections;

public class apple : MonoBehaviour {


    public int keepHanging;
    public float speed;
    public int scoreValue;
    private int h = 0;
    private bool drp;

    void Update()
    {
        if(!drp)
        {
           if (h <= keepHanging)
            {
                h++;
            }
            else
            {
                Drop();
            }
        }
        else
        {
            Vector3 p = this.transform.position;
            p.Set(p.x, p.y - speed, p.z);
            this.transform.position = p;
        }
    }

    public void Drop()
    {
        Debug.Log("Apple " + name + " was dropped.");
        drp = true;
    }

    public void Pickup(basket b)
    {
        b.AddScore(scoreValue);
        Destroy();
    }

    public void Destroy()
    {
        //cleanup
        Debug.Log("Apple " + name + " was destroyed.");
        GameObject.Destroy(this.gameObject);
    }
}

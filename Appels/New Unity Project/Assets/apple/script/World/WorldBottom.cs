using UnityEngine;
using System.Collections;

public class WorldBottom : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("collided with " + col);
        if (col.gameObject.tag == "pickup")
        {
            apple a = col.gameObject.GetComponent<apple>();
            a.Destroy();
        }
    }
}

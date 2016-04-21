using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
    float sx;
    float sy;
    Rigidbody r;

	// Use this for initialization
	void Start () {
        sx = Random.Range(0, 2) == 0 ? -1 : 1;
        sy = Random.Range(0, 2) == 0 ? -1 : 1;
        r = this.GetComponent<Rigidbody>();
        r.velocity = new Vector3(Random.Range(5, 10) * sx, Random.Range(5, 10) * sy);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

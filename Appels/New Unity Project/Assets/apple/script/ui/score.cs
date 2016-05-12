using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour{
    public GameObject playerToTrack;
    private basket p;

    void Start()
    {
        p = playerToTrack.GetComponent<basket>();
    }

	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 pp = playerToTrack.transform.position;
        transform.position.Set(pp.x, pp.y, pp.z);
	}
}

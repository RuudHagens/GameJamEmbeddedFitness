using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class playerBox : MonoBehaviour {
    public GameObject gamemanger;
    private _gameMGR mgr;
    private CollidedSphere mSph;
    private GameObject s;
    private bool hasSphere = false;
	// Use this for initialization
	void Start () {
        mSph = gamemanger.GetComponent<CollidedSphere>();
        mgr = gamemanger.GetComponent<_gameMGR>();
	}

    void OnTriggerEnter(Collider c)
    {
        int me;
        int u;
        if (c != null && c.transform.tag == "PlayerCollider")
        {
            if (hasSphere == false)
            {
                me = transform.parent.GetComponent<Player>().GetNumber();
                u = c.transform.parent.GetComponent<Player>().GetNumber();
                if (mgr.GetAnswer() == me + u)
                {
                    hasSphere = true;
                    Debug.Log("ayy");
                    List<GameObject> ps = new List<GameObject>();
                    ps.Add(transform.parent.gameObject);
                    ps.Add(c.transform.parent.gameObject);
                    s = mSph.spawnSphere(ps);
                }

            }
        }
    }

    void OnTriggerExit(Collider c)
    {
       
        if (s != null && hasSphere == true && c.transform.tag == "PlayerCollider")
        {
            Debug.Log("baleeted");
            GameObject.Destroy(s);
            hasSphere = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_ExplosionBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("destroyThis", 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void destroyThis()
    {
        Destroy(this.gameObject);
    }
}

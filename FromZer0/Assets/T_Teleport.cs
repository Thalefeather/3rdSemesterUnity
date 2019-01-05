using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Teleport : MonoBehaviour {

    [SerializeField] GameObject PC;
    [SerializeField] GameObject Camera;
    [Space]
    [SerializeField] GameObject Home;
    [SerializeField] GameObject Factory;
    [SerializeField] GameObject Boss;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void teleport (int location)
    {
        if(location == 0)
        {
            PC.transform.position = Home.transform.position;
            //PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.transform.position = Home.transform.position;
        }

        if (location == 1)
        {
            PC.transform.position = Factory.transform.position;
            //PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.transform.position = Factory.transform.position;
        }

        if (location == 2)
        {
            PC.transform.position = Boss.transform.position;
            //PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.transform.position = Boss.transform.position;
        }
    }
}

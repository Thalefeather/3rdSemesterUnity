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
    [Space]
    public bool teleported = false;
    [Space]
    [SerializeField] GameObject[] toRespawn;
    [SerializeField] GameObject door;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(teleported)
        {
            for(int i=0; i<toRespawn.Length; i++)
            {
                if(toRespawn[i]!= null)
                {
                    toRespawn[i].SetActive(true);
                }
            }

            door.SetActive(false);
        }
	}

    public void teleport (int location)
    {
        if(location == 0)
        {
            PC.transform.position = Home.transform.position;
            //PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.transform.position = Home.transform.position;
            teleported = true;
        }

        if (location == 1)
        {
            PC.transform.position = Factory.transform.position;
            //PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.transform.position = Factory.transform.position;
            teleported = true;
        }

        if (location == 2)
        {
            PC.transform.position = Boss.transform.position;
            //PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.transform.position = Boss.transform.position;
            teleported = true;
        }

        Invoke("setTeleportFalse", 0.5f);
    }

    public void setTeleportFalse()
    {
        teleported = false;
    }
}

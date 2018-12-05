using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_BatMovement : MonoBehaviour {

    public float speed = 10;

    // Use this for initialization
    void Start () {
        //var target = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //transform.position = Vector2.MoveTowards(transform.position, collision.gameObject.transform.position, speed * Time.deltaTime);

            //this.gameObject.GetComponent<Rigidbody2D>().velocity = this.gameObject.transform.up.normalized * speed;

            if (Vector2.Distance(this.transform.position, collision.gameObject.transform.position) >= 4)
            {
                transform.position = Vector2.MoveTowards(transform.position, collision.gameObject.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            //this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}

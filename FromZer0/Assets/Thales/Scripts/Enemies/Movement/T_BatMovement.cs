﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_BatMovement : MonoBehaviour {

    public float speed = 10;
    public float minimumDistanceToPlayer = 1.5f;
    public Rigidbody2D rb;
    [Space]
    public bool aggroed = false;
    public GameObject pc;

    public GameObject startingPosition;

    // Use this for initialization
    void Start () {
        //var target = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(aggroed)
        {
            FollowTargetWitouthRotation(pc.transform, minimumDistanceToPlayer, speed);
        }
        else
        {
            FollowTargetWitouthRotation(startingPosition.transform, 0, speed/2);
        }
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            aggroed = true;
            pc = collision.gameObject; 
        }
    }

    void FollowTargetWitouthRotation(Transform target, float distanceToStop, float speed)
    {
        var direction = Vector2.zero;
        if (Vector2.Distance(transform.position, target.position) > distanceToStop)
        {
            direction = target.position - transform.position;
            rb.velocity = direction.normalized * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnBecameInvisible()
    {
        aggroed = false;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour {

    public float speed;

    public int health;

    private Transform target;

	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


	}
	
	// Update is called once per frame
	void Update () {

        if (Vector2.Distance(transform.position, target.position) < 6)

        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
		
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("BAM!");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;
    public GameObject effect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

	}

    public void TakeDamage(int damage)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("BAM!");
    }
}

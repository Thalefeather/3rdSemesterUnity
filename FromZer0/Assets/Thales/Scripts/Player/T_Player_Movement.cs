﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Movement : MonoBehaviour {

    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float walkXPcounter = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();

    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        var newXpos = transform.position.x + deltaX;
        var newYpos = transform.position.y + deltaY;

        transform.position = new Vector2(newXpos, newYpos);

        

        walkXPcounter = walkXPcounter + Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));

        if(walkXPcounter>= 100)
        {
            walkXPcounter = 0;
            var array = this.GetComponent<T_SkillTracker>().Walking;
            this.GetComponent<T_SkillTracker>().EarnXp(array, 10);
        }


        //Debug.Log(angleOfMove());

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Movement : MonoBehaviour {

    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float walkXPcounter = 0;
    private Rigidbody2D rb;

    public bool canMove = false;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(this.GetComponent<T_Player_Inputs>().talking)//band aid fix for sliding while initiating talk and getting out of range
        {
            rb.velocity = Vector2.zero;
        }
        else if(canMove && !this.GetComponent<T_Dash>().isDashing)
        {
            Move();
            WalkingLevelUp();
        }
        
    }

    private void Move()
    {
        float deltaX;
        float deltaY;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        /*float newXpos;
        float newYpos;

        deltaX = inputX * Time.deltaTime * moveSpeed;
        deltaY = inputY * Time.deltaTime * moveSpeed;

        newXpos = transform.position.x + deltaX;
        newYpos = transform.position.y + deltaY;

        transform.position = new Vector2(newXpos, newYpos);
        */

        rb.velocity = new Vector2(inputX * moveSpeed * Time.deltaTime, inputY * moveSpeed * Time.deltaTime);

        //code to change the players "up" to the direction of movement
        if(inputX!=0 || inputY!=0)
        {
            this.gameObject.transform.up = new Vector2(inputX, inputY).normalized;
        }

        //rb.velocity = new Vector2(deltaX, deltaY);

    }

    private void WalkingLevelUp()
    {
        //this will lead to xp always be earned when holding directional inputs, nezed to adapt so its only when walking
        walkXPcounter = walkXPcounter + Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));

        if (walkXPcounter >= 100)
        {
            walkXPcounter = 0;
            var array = this.GetComponent<T_SkillTracker>().Walking;
            this.GetComponent<T_SkillTracker>().EarnXp(array, 10, false);
        }
    }


}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerLaserBehavior : MonoBehaviour {

    [SerializeField] float projectileSpeed = 50f;
    [SerializeField] float timeToFade = 0.5f;
    [SerializeField] float damage = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveForward();

    }

    void MoveForward()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.up.normalized * projectileSpeed;

        //this.transform.up = this.GetComponent<Rigidbody2D>().velocity;
    }


    private void OnBecameInvisible()
    {
        Invoke("DestroyOutOfBounds", timeToFade);
    }

    private void DestroyOutOfBounds()
    {
        Destroy(this.gameObject);
    }

    private void dealDamage(GameObject thingHit)
    {
        Debug.Log("damage dealt to enemy");
        thingHit.GetComponent<T_Health>().TakeDamage(damage);

        //Make sure method is set to public! this is example of how to call function from another object
        //thingHit.GetComponent<T_Player_Movement>().Move();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //declare collider to be able to tell them apart when calculating collisions
        //body cant be trigger, is the bad. maybe give it a trigger and a not trigger?
        //public BoxCollider collider1;

        if(collision.tag != "Player")
        {
            Debug.Log("OnTriggerEnter2D");
        }

        //stops here, connects but doesnt diffrentiate between the 2 colliders

        //if (collision.GetComponent<Collider2D>() == collision.GetComponent<T_Body_Collider>().Body)
        //{
        //Debug.Log("collided with *BODY*");
        //dealDamage(collision);
        //}
        //var body = collision.gameObject.GetComponent<CircleCollider2D>();
        //var enemy = collision.gameObject.GetComponent<T_Body_Collider>().Body;
        //if ( body == enemy)
        //if (collision.tag == "Enemy")


        if(collision.tag == "EnemyBody")
        {
            Debug.Log("collided with *BODY*");
            dealDamage(collision.transform.parent.gameObject);
            TallyXpRanged();
            //hitStop(collision);

            Destroy(this.gameObject);

        }

    }

    private void TallyXpRanged()
    {
        GameObject PC = GameObject.Find("Player");
        // doenst work for the same reason that Ranged up didnt work => the Player object isnt the 'parent' of the script. Even happened using GameObject.Find need to figure out how to make this work!
        var array = PC.GetComponent<T_SkillTracker>().Ranged;
        PC.GetComponent<T_SkillTracker>().EarnXp(array, 10);
    }

    private void hitStop(Collider2D enemy)
    {

        //makes enemy invisible but can still do stuff
        enemy.transform.parent.GetComponent<Renderer>().enabled = false;



    }

    


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_BatAttack : MonoBehaviour {

    public CircleCollider2D body;
    public float damage = 5;
    public float timeToAttack=0;
    public float attackCooldown = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        Debug.Log("hit");
//        dealDamage(collision.gameObject);
//    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("hit");
        timeToAttack = timeToAttack - Time.deltaTime;

        if(timeToAttack<=0)
        {
            dealDamage(collision.gameObject);
            Debug.Log("hitTime");
            timeToAttack = attackCooldown;
        }
    }

    //type => 0 == ranged
    //type => 1 == melee
    //type => 2 == special
    private void dealDamage(GameObject thingHit)
    {
        Debug.Log("damage dealt to Player");
        thingHit.GetComponent<T_Health>().TakeDamage(damage, 1);
    }
}

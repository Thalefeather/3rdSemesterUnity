using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerLaserBehavior : MonoBehaviour {

    [SerializeField] float projectileSpeed = 50f;
    [SerializeField] float timeToFade = 0.5f;
    [SerializeField] float rawDamage = 10f;
    [SerializeField] float finalDamage = 0f;

    GameObject PC;

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

    //type => 0 == ranged
    //type => 1 == melee
    //type => 2 == special
    private void dealDamage(GameObject thingHit)
    {
        PC = GameObject.Find("Player");
        Debug.Log("damage dealt to enemy");
        
        finalDamage = rawDamage + PC.GetComponent<T_SkillTracker>().Ranged[0];
        thingHit.GetComponent<T_Health>().TakeDamage(finalDamage, 0);
        Debug.Log(finalDamage);
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
        else
        if(collision.tag == "SolidEnviromentObject")
        {
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


    


}


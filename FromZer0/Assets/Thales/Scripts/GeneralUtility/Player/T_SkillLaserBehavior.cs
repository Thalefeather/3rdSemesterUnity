using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_SkillLaserBehavior : MonoBehaviour {

    [SerializeField] float projectileSpeed = 35f;
    [SerializeField] float timeToFade = 0.5f;
    [SerializeField] float damage = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.up.normalized * projectileSpeed;
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
        Debug.Log("damage dealt to enemy");
        thingHit.GetComponent<T_Health>().TakeDamage(damage, 2);

        //Make sure method is set to public! this is example of how to call function from another object
        //thingHit.GetComponent<T_Player_Movement>().Move();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Debug.Log("OnTriggerEnter2D");
        }

        if (collision.tag == "EnemyBody")
        {
            Debug.Log("collided with *BODY*");
            dealDamage(collision.transform.parent.gameObject);
            TallyXpRanged();
            //hitStop(collision);
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

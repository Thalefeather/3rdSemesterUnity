using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_MeleeAttack : MonoBehaviour {


    [SerializeField] float timeBetweenAttacks = 2f;
    [SerializeField] float currentTimeBetweenAttacks = 0f;
    [SerializeField] float attackRange = 2f;
    [SerializeField] GameObject slash;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CountDownAndAttack(collision);
        }
    }

    private void CountDownAndAttack(Collider2D collision)
    {
        currentTimeBetweenAttacks -= Time.deltaTime;

        if(currentTimeBetweenAttacks <= 0.5f && Vector2.Distance(this.transform.position, collision.gameObject.transform.position) <= this.GetComponent<T_EnemyMovement>().minimumDistanceToPlayer)
        {
            attackColor();
            Invoke("attack", 0.5f);
            Invoke("mainColor", 0.5f);
            currentTimeBetweenAttacks = timeBetweenAttacks;
        }
    }

    private void attack()
    {
        GameObject attack = Instantiate(slash, this.transform.position + this.transform.up.normalized/attackRange, this.transform.rotation);
        currentTimeBetweenAttacks = timeBetweenAttacks;
    }

    private void print2()
    {
        Debug.Log("ATTACK ATTACK ATTACK");
        currentTimeBetweenAttacks = timeBetweenAttacks;
    }

    private void mainColor()
    {
        GetComponent<SpriteRenderer>().color = new Color(46, 255, 0);
    }

    private void attackColor()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CountDownAndAttack(collision);
        }
    }

    private void CountDownAndAttack(Collider2D collision)
    {
        currentTimeBetweenAttacks -= Time.deltaTime;

        if (currentTimeBetweenAttacks < 0.5 && currentTimeBetweenAttacks > 0 && Vector2.Distance(this.transform.position, collision.gameObject.transform.position) <= 6.3)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(46, 255, 0);
        }

        if (currentTimeBetweenAttacks <= 0 && Vector2.Distance(this.transform.position, collision.gameObject.transform.position) <= 6.3)
        {

            //GameObject attack = Instantiate(slash, this.transform.position + this.transform.up.normalized * 3, Quaternion.Euler(0, 0, Vector2.Angle(this.transform.up.normalized, collision.transform.position)));
            GameObject attack = Instantiate(slash, this.transform.position + this.transform.up.normalized * 3, this.transform.rotation);
            Debug.Log("THIS POS" + collision.transform.position);
            Debug.Log(this.transform.up);
            currentTimeBetweenAttacks = timeBetweenAttacks;

        }
    }*/


}

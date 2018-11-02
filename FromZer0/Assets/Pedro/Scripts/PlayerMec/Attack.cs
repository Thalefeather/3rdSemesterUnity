using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int AnimAtackSpeed;

    public int damage = 25;
    private ShakeScreen shake;

    Collider2D swordcol;
   
    Animator myAnimator;

    void Start()
    {
        swordcol = GameObject.Find("Sword").GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.speed = AnimAtackSpeed;
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeScreen>();
    }



    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.J))
            {
                myAnimator.SetTrigger("attack");
                //shake.CamShake();
            }

            timeBtwAttack = startTimeBtwAttack;

        }
        else
        { 
            timeBtwAttack -= Time.deltaTime;
        }

    }

    void StartAttackAnim()
    {
        swordcol.enabled = true;
    }

    void EndAttackAnim()
    {
        swordcol.enabled = false;
        myAnimator.ResetTrigger ("attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBody")
        {
            Debug.Log("SWORD collided with *BODY*");
            dealDamage(collision.transform.parent.gameObject);
            //hitStop(collision);
        }

    }


    //0 ranged
    //1 melee
    //2 special
    private void dealDamage(GameObject thingHit)
    {
        Debug.Log("damage dealt to enemy");
        thingHit.GetComponent<T_Health>().TakeDamage(damage, 1);
    }
}


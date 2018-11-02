using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_BossProjectileHorizontal : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float timeToFade = 0.5f;
    [SerializeField] float damage = 10f;

    [SerializeField] bool LeftToRight = true;


    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        if(LeftToRight)
        {
            this.GetComponent<Rigidbody2D>().velocity = this.transform.right.normalized * projectileSpeed;
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = this.transform.right.normalized * -projectileSpeed;
        }
        
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
        Debug.Log("damage dealt to Player");
        thingHit.GetComponent<T_Health>().TakeDamage(damage, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag != "Enemy")
        {
            Debug.Log("OnTriggerEnter2D");
        }

        if (collision.tag == "PlayerBody")
        {
            Debug.Log("collided with *BODY*");
            dealDamage(collision.transform.parent.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.tag == "SolidEnviromentObject")
        {
            Destroy(this.gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_MeleeSlash : MonoBehaviour {

    [SerializeField] float timeToFade = 0.5f;
    [SerializeField] float damage = 25f;
    [SerializeField] bool hit = false;


    private void Start()
    {
        this.transform.Rotate(0, 0, 90);
        Invoke("endSlash", timeToFade);
    }

    //type => 0 == ranged
    //type => 1 == melee
    //type => 2 == special
    private void dealDamage(GameObject thingHit)
    {
        Debug.Log("damage dealt to Player");
        thingHit.GetComponent<T_Health>().TakeDamage(damage, 1);
        hit = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && hit == false)
        {
            Debug.Log("collided with *BODY*");
            dealDamage(collision.gameObject);
        }
    }

    private void endSlash ()
    {
        Destroy(this.gameObject);
    }

}

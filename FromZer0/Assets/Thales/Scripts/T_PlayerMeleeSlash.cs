using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerMeleeSlash : MonoBehaviour {

    [SerializeField] float timeToFade = 0.1f;
    [SerializeField] float damage = 25f;
    private float finalDamage = 0;
    GameObject PC;


    private void Start()
    {
        PC = GameObject.Find("Player");
        this.transform.Rotate(0, 0, 90);
        Invoke("endSlash", timeToFade);
    }

    //type => 0 == ranged
    //type => 1 == melee
    //type => 2 == special
    private void dealDamage(GameObject thingHit)
    {
        finalDamage = damage + PC.GetComponent<T_SkillTracker>().Melee[0] + PC.GetComponent<T_SkillTracker>().meleeGear;
        Debug.Log(finalDamage+" MELEE damage dealt to Enemy");
        thingHit.GetComponent<T_Health>().TakeDamage(finalDamage, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBody")
        {
            dealDamage(collision.transform.parent.gameObject);
            TallyXpMelee();
        }
    }

    private void endSlash ()
    {
        Destroy(this.gameObject);
    }

    private void TallyXpMelee()
    {
        var array = PC.GetComponent<T_SkillTracker>().Melee;
        PC.GetComponent<T_SkillTracker>().EarnXp(array, 20, false);
    }

}

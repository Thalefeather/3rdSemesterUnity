using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int AnimAtackSpeed;

    public float rawDamage = 25;
    public float finalDamage = 0;
    private ShakeScreen shake;

    Collider2D swordcol;
   
    Animator myAnimator;

    GameObject PC;

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
        PC = GameObject.Find("Player");

        Debug.Log("damage dealt to enemy");

        Debug.Log(finalDamage);
        finalDamage = rawDamage + PC.GetComponent<T_SkillTracker>().Melee[0] + PC.GetComponent<T_SkillTracker>().meleeGear;
        thingHit.GetComponent<T_Health>().TakeDamage(finalDamage, 1);

        TallyXpMelee();
    }

    private void TallyXpMelee()
    {
        PC = GameObject.Find("Player");
        // doenst work for the same reason that Ranged up didnt work => the Player object isnt the 'parent' of the script. Even happened using GameObject.Find need to figure out how to make this work!
        var array = PC.GetComponent<T_SkillTracker>().Melee;
        PC.GetComponent<T_SkillTracker>().EarnXp(array, 20, false);
    }
}


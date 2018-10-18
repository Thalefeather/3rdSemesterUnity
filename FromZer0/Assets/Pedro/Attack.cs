using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int AnimAtackSpeed;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    Collider2D swordcol;
   
    Animator myAnimator;

        void Start()
    {
        swordcol = GameObject.Find("Sword").GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.speed = AnimAtackSpeed;
    }



    // Update is called once per frame
    void Update()
    {

        
        

            if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
 
            {
               
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                   // enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    enemiesToDamage[i].GetComponent<BatMovement>().TakeDamage(damage);

                }
                myAnimator.SetTrigger("attack");
            }

            

            timeBtwAttack = startTimeBtwAttack;

        }
        else
        {
            
            timeBtwAttack -= Time.deltaTime;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void AttackAnim()
    {
        swordcol.enabled = true;
    }

    void NoAttackAnim()
    {
        swordcol.enabled = false;
        myAnimator.ResetTrigger ("attack");
    }
}


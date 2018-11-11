using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_EnemyMelee : MonoBehaviour {

    public float speed;
    public int AnimAtackSpeed;
    Animator myAnimator;
    Collider2D swordcol;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.speed = AnimAtackSpeed;

        swordcol = GameObject.Find("EnemySword").GetComponent<Collider2D>(); 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Take Damage to the player 
        }
    }

    private void AttackAnimation()
    {
 
        myAnimator.SetTrigger("attack");
    }

    public void Attack()
    {

        InvokeRepeating("AttackAnimation", 2.0f, 0.3f);
    }


    void StartAttackAnim()
    {
        swordcol.enabled = true;
    }

    void EndAttackAnim()
    {
        swordcol.enabled = false;
        myAnimator.ResetTrigger("attack");
    }
}

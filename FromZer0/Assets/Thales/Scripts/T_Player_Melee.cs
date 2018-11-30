using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Melee : MonoBehaviour {

    [SerializeField] float attackCounter = 0;
    [SerializeField] float attackRate = 0.5f;
    [Space]
    [SerializeField] GameObject slash;

    private void Update()
    {
        attack();
        attackCounter = attackCounter - Time.deltaTime;
    }

    private void attack()
    {
        if (Input.GetButton("Fire2"))
        {
            if (attackCounter <= 0)
            {
                executeAttack();
                attackCounter = attackRate;
            }
        }
    }

    private void executeAttack()
    {
        GameObject attackObject = Instantiate(slash, this.transform.position + this.transform.up.normalized * 3, this.transform.rotation);
    }
}

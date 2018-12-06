using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Melee : MonoBehaviour {

    [SerializeField] float attackCounter = 0;
    [SerializeField] float attackRate = 0.5f;
    [SerializeField] float attackRange = 2f;
    [Space]
    [SerializeField] float currentComboAttack = 0;
    [SerializeField] float amountOfTimeToComboIntoNextAttack = 1;
    [SerializeField] float breakComboStringCounter = 1;
    [Space]
    [SerializeField] GameObject slash0;
    [SerializeField] GameObject slash1;
    [SerializeField] GameObject slash2;

    private void Update()
    {
        //attack();
        attackCounter = attackCounter - Time.deltaTime;

        breakComboStringCounter = breakComboStringCounter - Time.deltaTime;

        if(breakComboStringCounter < 0)
        {
            currentComboAttack = 0;
        }

        if(currentComboAttack == 0)
        {
            this.GetComponent<T_Player_Inputs>().inCombo = false;
        }
        else
        {
            this.GetComponent<T_Player_Inputs>().inCombo = true;
        }
    }

    public void attack()
    {
        Debug.Log("ATTACK IS CALLED");

        if (breakComboStringCounter >= 0 && currentComboAttack == 2)
        {
            executeAttack2();
            currentComboAttack = 0;
            breakComboStringCounter = 0;
            Debug.Log("slash 2");
            attackCounter = attackRate;
        }

        if (breakComboStringCounter >= 0 && currentComboAttack == 1)
        {
            executeAttack1();
            currentComboAttack++;
            breakComboStringCounter = amountOfTimeToComboIntoNextAttack;
            Debug.Log("slash 1");
        }

        if (attackCounter <= 0 && currentComboAttack == 0)
        {
            executeAttack0();
            currentComboAttack++;
            breakComboStringCounter = amountOfTimeToComboIntoNextAttack;
            //attackCounter = attackRate;
            Debug.Log("slash 0");
        }
    }

    private void executeAttack0()
    {
        GameObject attackObject = Instantiate(slash0, this.transform.position + this.transform.up.normalized/attackRange, this.transform.rotation);
    }

    private void executeAttack1()
    {
        GameObject attackObject = Instantiate(slash1, this.transform.position + this.transform.up.normalized / attackRange, this.transform.rotation);
    }

    private void executeAttack2()
    {
        GameObject attackObject = Instantiate(slash2, this.transform.position + this.transform.up.normalized / attackRange, this.transform.rotation);
    }
}

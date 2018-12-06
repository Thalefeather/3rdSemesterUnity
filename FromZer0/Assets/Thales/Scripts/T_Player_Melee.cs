using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Melee : MonoBehaviour {

    [SerializeField] float attackCounter = 0;
    [SerializeField] float attackRate = 0.5f;
    [SerializeField] float attackRange = 2f;
    [Space]
    //[SerializeField] float currentComboAttack = 0;
    //[SerializeField] float amountOfTimeToComboIntoNextAttack = 1;
    //[SerializeField] float breakComboStringCounter = 1;
    [Space]
    public int noOfClicks = 0;//Time when last button was clicked
    public float lastClickedTime = 0;//Delay between clicks for which clicks will be considered as combo
    public float maxComboDelay = 0.2f;
    public float spaceBetweenClicks = 0;
    [Space]
    public float delayCombo1to2 = 0.1f;
    public float delayCombo2to3 = 0.1f;
    [Space]
    [SerializeField] GameObject slash0;
    [SerializeField] GameObject slash1;
    [SerializeField] GameObject slash2;

    private void Update()
    {
        //attack();
        attackCounter = attackCounter - Time.deltaTime;

        //breakComboStringCounter = breakComboStringCounter - Time.deltaTime;



        /*
        if(breakComboStringCounter < 0)
        {
            currentComboAttack = 0;
        }*/

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (noOfClicks == 0)
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
        //Debug.Log("ATTACK IS CALLED");
        //Record time of last button click
        spaceBetweenClicks = Time.time - lastClickedTime;
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1 && attackCounter <= 0)
        {
            //animator.SetBool("Attack1", true);
            executeAttack1();
        }
        if (noOfClicks == 1 && attackCounter > 0)
        {
            noOfClicks = 0;
        }
        if (noOfClicks == 2)
        {
            //animator.SetBool("Attack1", true);
            executeAttack2();
            //Invoke("executeAttack2", delayCombo1to2);
        }
        if (noOfClicks == 3)
        {
            //animator.SetBool("Attack1", true);
            executeAttack3();
            //Invoke("executeAttack3", delayCombo2to3);
            noOfClicks = 0;
            attackCounter = attackRate;
        }
        
        //limit/clamp no of clicks between 0 and 3 because you have combo for 3 clicks
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
    }

    private void executeAttack1()
    {
        GameObject attackObject = Instantiate(slash0, this.transform.position + this.transform.up.normalized/attackRange, this.transform.rotation);
    }

    private void executeAttack2()
    {
        GameObject attackObject = Instantiate(slash1, this.transform.position + this.transform.up.normalized / attackRange, this.transform.rotation);
    }

    private void executeAttack3()
    {
        GameObject attackObject = Instantiate(slash2, this.transform.position + this.transform.up.normalized / attackRange, this.transform.rotation);
    }


    /////////

    /*void OldAttack()
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
    }*/
}

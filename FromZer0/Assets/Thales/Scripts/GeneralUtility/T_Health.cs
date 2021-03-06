﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Health : MonoBehaviour {
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] public float currentHealth = 10f;
    [SerializeField] float XpWorth = 10f;
    [SerializeField] float CurrencyWorth = 75f;

    public SimpleHealthBar healthBar;

    [SerializeField] public float maxSP = 100f;
    [SerializeField] public float currentSP = 0f;

    public SimpleHealthBar SPBar;

    GameObject PC;
    private Rigidbody2D rb;

    public GameObject pauseManager;
    private bool dead = false;


    // Use this for initialization
    void Start () {
        if (this.gameObject.tag == "Player")//for players
        {
            currentSP = maxSP;
            SPBar.UpdateBar(currentSP, maxSP);
            rb = GetComponent<Rigidbody2D>();
            this.GetComponent<T_Player_Inputs>().dead = false;
        }
        else//for enemies
        {
            PC = GameObject.Find("Player");
            
        }
    }

    private void CheckIfDeadThenKill ()
    {
        if(currentHealth<=0)
        {
            if(this.gameObject.tag != "Player")
            {
                TallyXpPlayer(XpWorth);
                TallyCurrency(CurrencyWorth);

                this.gameObject.GetComponent<T_LootTable>().spawnBestDrop();
                //Destroy(this.gameObject);
                this.gameObject.SetActive(false);

                
            }
            else if(this.gameObject.tag == "Player" && !dead)//if its the player and he aint dead yet
            {
                pauseManager.GetComponent<T_PauseManager>().DeadPause();
                dead = true;
                this.GetComponent<T_Player_Inputs>().dead = true;
            }

            
        }
    }

    //type => 0 == ranged
    //type => 1 == melee
    //type => 2 == special
    public void TakeDamage(float dmg, float type)
    {
        if (this.gameObject.tag == "Player")
        {
            Debug.Log("velocity while taking damge: "+rb.velocity.x + " " +rb.velocity.y);
            if (!this.GetComponent<T_Dash>().isDashing)
            { 
                currentHealth = currentHealth - this.gameObject.GetComponent<T_SkillTracker>().defenseModifier(dmg);
                Debug.Log(this.gameObject.GetComponent<T_SkillTracker>().defenseModifier(dmg));
                TallyXpDefense();
            }
            else
            {
                Debug.Log("IFRAMES!");
            }

            healthBar.UpdateBar(currentHealth, maxHealth);
        }
        else
        if (type == 0)
        {
            //PC.GetComponent<T_Health>().EarnSP(10);
            currentHealth = currentHealth - dmg;
        }
        else
        if (type == 1)
        {
            //PC.GetComponent<T_Health>().EarnSP(20);
            currentHealth = currentHealth - dmg;
        }
        if (type == 2)
        {
            currentHealth = currentHealth - dmg;
        }


        CheckIfDeadThenKill();
    }

    public void Heal(float amount)
    {
        if(currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
            healthBar.UpdateBar(currentHealth, maxHealth);
        }
        else
        {
            currentHealth = currentHealth + amount;
            healthBar.UpdateBar(currentHealth, maxHealth);
        }
    }

    private void TallyXpDefense()
    {
        var array = this.GetComponent<T_SkillTracker>().Defense;
        this.GetComponent<T_SkillTracker>().EarnXp(array, 10, false);
    }

    public void TallyXpPlayer(float amount)
    {
        //GameObject PC = GameObject.Find("Player");
        // doenst work for the same reason that Ranged up didnt work => the Player object isnt the 'parent' of the script. Even happened using GameObject.Find need to figure out how to make this work!
        var array = PC.GetComponent<T_SkillTracker>().Player;
        PC.GetComponent<T_SkillTracker>().EarnXp(array, amount, true);
        
    }

    private void TallyCurrency(float amount)
    {
        GameObject PC_Inventory = GameObject.Find("TInventory");

        PC_Inventory.GetComponent<T_CurrencyManager>().earnCurrency(amount);
    }

    private void EarnSP (float amount)
    {
        if (currentSP + amount > maxSP)
        {
            currentSP = maxSP;
            SPBar.UpdateBar(currentSP, maxSP);
        }
        else
        {
            currentSP = currentSP + amount;
            SPBar.UpdateBar(currentSP, maxSP);
        }
    }

    public void LoseSP(float amount)
    {
        currentSP = currentSP - amount;
        SPBar.UpdateBar(currentSP, maxSP);
    }

    public void FullRestore()
    {
        //currentSP = maxSP;
        //currentHealth = maxHealth;

        EarnSP(maxSP);
        Heal(maxHealth);

        //Debug.Log("FULLRESTORE IN THEALHT");
    }
}

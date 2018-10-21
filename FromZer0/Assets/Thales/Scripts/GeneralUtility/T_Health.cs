using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Health : MonoBehaviour {

    [SerializeField] public float maxHealth = 10f;
    [SerializeField] public float currentHealth = 10f;
    [SerializeField] float XpWorth = 10f;
    [SerializeField] float CurrencyWorth = 75f;

    public SimpleHealthBar healthBar;


    // Use this for initialization
    void Start () {
		
	}
	
    private void CheckIfDeadThenKill ()
    {
        if(currentHealth<=0)
        {
            if(this.gameObject.tag != "Player")
            {
                TallyXpPlayer(XpWorth);
                TallyCurrency(CurrencyWorth);
            }

            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float dmg)
    {
        
        

        if(this.gameObject.tag == "Player")
        {
            currentHealth = currentHealth - this.gameObject.GetComponent<T_SkillTracker>().defenseModifier(dmg);
            Debug.Log(this.gameObject.GetComponent<T_SkillTracker>().defenseModifier(dmg));
            TallyXpDefense();

            healthBar.UpdateBar(currentHealth, maxHealth);
        }
        else
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

    private void HitStunAndKnockback()
    {

    }

    private void DeathAnimation()
    {

    }

    private void DisplayHealth()
    {

    }

    private void TallyXpDefense()
    {
        var array = this.GetComponent<T_SkillTracker>().Defense;
        this.GetComponent<T_SkillTracker>().EarnXp(array, 10);
    }

    private void TallyXpPlayer(float amount)
    {
        GameObject PC = GameObject.Find("Player");
        // doenst work for the same reason that Ranged up didnt work => the Player object isnt the 'parent' of the script. Even happened using GameObject.Find need to figure out how to make this work!
        var array = PC.GetComponent<T_SkillTracker>().Player;
        PC.GetComponent<T_SkillTracker>().EarnXp(array, amount);
        
    }

    private void TallyCurrency(float amount)
    {
        GameObject PC_Inventory = GameObject.Find("Inventory");

        PC_Inventory.GetComponent<T_CurrencyManager>().earnCurrency(amount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Health : MonoBehaviour {

    [SerializeField] float maxHealth = 10f;
    [SerializeField] float currentHealth = 10f;


    // Use this for initialization
    void Start () {
		
	}
	
    private void CheckIfDeadThenKill ()
    {
        if(currentHealth<=0)
        {
            if(this.gameObject.tag != "Player")
            {
                TallyXpPlayer();
            }

            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth = currentHealth - dmg;
        CheckIfDeadThenKill();

        if(this.gameObject.tag == "Player")
        {
            TallyXpDefense();
        }
    }

    public void Heal(float amount)
    {

        if(currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = currentHealth + amount;
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

    private void TallyXpPlayer()
    {
        GameObject PC = GameObject.Find("Player");
        // doenst work for the same reason that Ranged up didnt work => the Player object isnt the 'parent' of the script. Even happened using GameObject.Find need to figure out how to make this work!
        var array = PC.GetComponent<T_SkillTracker>().Player;
        PC.GetComponent<T_SkillTracker>().EarnXp(array, 10);

       

        
    }
}

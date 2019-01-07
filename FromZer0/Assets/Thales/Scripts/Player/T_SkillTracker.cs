using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_SkillTracker : MonoBehaviour {
    //should be a different way to do it where i can have all the XP gains saved in this script, try later though.

    [SerializeField] GameObject PC_CanvasSkillUp;
    [SerializeField] GameObject PC_CanvasLevelUp;
    [Space]
    //[0] is lvl
    //[1] is xp
    //[2] is xp needed to lvl
    [SerializeField] public float[] Player = new float[3];
    [SerializeField] public float[] Walking = new float[3];
    [SerializeField] public float[] Ranged = new float[3];
    [SerializeField] public float[] Melee = new float[3];
    [SerializeField] public float[] Defense = new float[3];

    public float defenseGear=0;
    public float meleeGear=0;
    public float rangedGear = 0;




    private void Start()
    {
        initiateArray(Player);
        initiateArray(Walking);
        initiateArray(Ranged);
        initiateArray(Melee);
        initiateArray(Defense);

        //ranged doesnt earn xp, only after "play/pause" is done. deleted the lines of code, leave for last implementation after melee
    }


    public void EarnXp(float[] toEarn, float amount, bool Playerlevel)
    {
        toEarn[1] = toEarn[1] + amount;

        if(toEarn[1] >= toEarn[2])
        {
            var dif = toEarn[1] - toEarn[2];
            toEarn[0]++;
            toEarn[1] = 0 + dif;
            toEarn[2] = (50*(toEarn[0]*toEarn[0])) - (150*toEarn[0]) + 200; 
            //50lvl2−150lvl+200

            EarnXp(toEarn, 0, Playerlevel);

            if(Playerlevel)
            {
                this.gameObject.GetComponent<T_Health>().maxHealth += 10;//earn more health per level and heal
                this.gameObject.GetComponent<T_Health>().Heal(10);
                this.gameObject.GetComponent<T_Health>().maxSP += 10;//earn more sp per level and add it
                this.gameObject.GetComponent<T_Health>().currentSP = this.gameObject.GetComponent<T_Health>().maxSP;
                this.gameObject.GetComponent<T_Health>().LoseSP(0);//so the bar will update
                levelUpOn();
            }
            else
            {
                skillUpOn();
                this.gameObject.GetComponent<T_Health>().maxSP += 1;//earn more sp per level and add it
                this.gameObject.GetComponent<T_Health>().currentSP += 1;
                this.gameObject.GetComponent<T_Health>().LoseSP(0);//so the bar will update
            }
            
        }
    }

    private void initiateArray(float[] Array)
    {
        Array[0] = 1;
        Array[1] = 0;
        Array[2] = 50 * (Array[0] * Array[0]) - (150 * Array[0]) + 200;
    }

    public float defenseModifier(float damage)
    {
        float lvl = Defense[0];

        float final;

        final = damage*(100 / (100 + lvl + defenseGear));

        return final;
    }

    public float rangedModifier(float damage)
    {
        float lvl = Ranged[0];

        float final;

        final = damage + lvl + rangedGear;

        return final;
    }

    public float meleeModifier(float damage)
    {
        float lvl = Melee[0];

        float final;

        final = damage * (lvl + meleeGear + 4);
        

        return final;
    }

    private void skillUpOn()
    {
        PC_CanvasSkillUp.SetActive(true);
        Invoke("skillUpOff", 1f);
    }
    private void skillUpOff()
    {
        PC_CanvasSkillUp.SetActive(false);
    }

    private void levelUpOn()
    {
        PC_CanvasLevelUp.SetActive(true);
        Invoke("levelUpOff", 1f);
    }
    private void levelUpOff()
    {
        PC_CanvasLevelUp.SetActive(false);
    }



}

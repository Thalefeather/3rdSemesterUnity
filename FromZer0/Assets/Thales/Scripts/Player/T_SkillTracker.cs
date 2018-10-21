using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_SkillTracker : MonoBehaviour {
    //should be a different way to do it where i can have all the XP gains saved in this script, try later though.


    //[0] is lvl
    //[1] is xp
    //[2] is xp needed to lvl
    [SerializeField] public float[] Player = new float[3];
    [SerializeField] public float[] Walking = new float[3];
    [SerializeField] public float[] Ranged = new float[3];
    [SerializeField] public float[] Melee = new float[3];
    [SerializeField] public float[] Defense = new float[3];

    private void Start()
    {
        initiateArray(Player);
        initiateArray(Walking);
        initiateArray(Ranged);
        initiateArray(Melee);
        initiateArray(Defense);

        //ranged doesnt earn xp, only after "play/pause" is done. deleted the lines of code, leave for last implementation after melee
    }


    public void EarnXp(float[] toEarn, float amount)
    {
        toEarn[1] = toEarn[1] + amount;

        if(toEarn[1] >= toEarn[2])
        {
            var dif = toEarn[1] - toEarn[2];
            toEarn[0]++;
            toEarn[1] = 0 + dif;
            toEarn[2] = (50*(toEarn[0]*toEarn[0])) - (150*toEarn[0]) + 200; //set the new xp to level as 100 times the level number
            //50lvl2−150lvl+200
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
        float gear = 0;

        float final;

        final = damage*(100 / (100 + lvl + gear));

        return final;
    }



}

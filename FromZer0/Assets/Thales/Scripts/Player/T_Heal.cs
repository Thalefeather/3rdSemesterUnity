using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Heal : MonoBehaviour {

    [SerializeField] float healPerTick = 1;
    [SerializeField] float tickLength = 0.1f;
    [SerializeField] float totalTicks = 10;
    [SerializeField] float cooldown = 5;
    [SerializeField] float useCounter = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        useCounter -= Time.deltaTime;

        if(Input.GetButtonDown("Fire3") && useCounter<=0)
        {
            Heal();
            useCounter = cooldown;
        }
		
	}
    void Heal()
    {
        //need to make this framerate independant
        float counter = 1;

        while(counter<=totalTicks)
        {
            counter++;
            this.GetComponent<T_Health>().Heal(healPerTick);
        }
        
    }

}

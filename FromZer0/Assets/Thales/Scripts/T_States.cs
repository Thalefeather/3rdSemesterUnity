using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_States : MonoBehaviour {

    public int npc1Return = 0;
    public int npc1DialogIndex = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void setStateTo (int npc, int value)
    {
        if(npc == 1)
        {
            updateNpc1(value);
        }
    }

    public void updateNpc1 (int currentState)
    {
        if (currentState == -1)//idle state
        {
            npc1Return = -1;
        }
        if (currentState == 0)
        {
            npc1DialogIndex = 0;
        }
        if (currentState == 1)
        {
            npc1DialogIndex = 1;
        }

    }
}

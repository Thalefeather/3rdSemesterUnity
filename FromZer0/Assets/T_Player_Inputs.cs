﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Inputs : MonoBehaviour {

    GameObject ui;

    T_Player_Melee pcMelee;
    T_Player_Shooting pcRanged;
    T_Special_Attacks pcSpecial;

    T_Dash pcDash;
    T_Player_Movement pcMovement;

    T_PauseManager uiMenu;
    T_DialogManager uiDialog;

    //states
    public bool idle = false;
    public bool moving = false;
    public bool dashing = false;
    public bool paused = false;

    [Space]

    public bool talking = false;
    public bool endOfSentence = false;

    [Space]

    public bool dead = false;


    // Use this for initialization
    void Start () {

        ui = GameObject.Find("UIManagers");

        //attacks
        pcMelee = this.GetComponent<T_Player_Melee>();
        pcRanged = this.GetComponent<T_Player_Shooting>();
        pcSpecial = this.GetComponent<T_Special_Attacks>();

        //movement
        pcDash = this.GetComponent<T_Dash>();
        pcMovement = this.GetComponent<T_Player_Movement>(); //havent done anything with this yet because unsure of how to put input listner for axis here

        //UI stuff
        uiMenu = ui.transform.GetChild(1).GetComponent<T_PauseManager>();
        uiDialog = ui.transform.GetChild(3).GetComponent<T_DialogManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!talking && !paused && !dead)
        {
            //melee Attack
            if (Input.GetButtonDown("Fire2"))
            {
                pcMelee.attack();
            }

            //ranged Attack
            if (Input.GetButton("Fire1"))
            {
                pcRanged.fire();
            }

            //use special
            if (Input.GetButtonDown("Fire3"))
            {
                pcSpecial.useActiveSkill();
            }

            //toggle swap active skill
            if (Input.GetButtonDown("Toggle Power"))
            {
                pcSpecial.toggleSwapActiveSkill();
            }

            //dash
            if (Input.GetButtonDown("Dash"))
            {
                pcDash.doDash();
            }

        }


        //movement
        if(talking || paused || dead) //because of pausing timescale = 0 the bool doesnt switch but appears to work as intended anyway
        {
            pcMovement.canMove = false;
        }
        else
        {
            pcMovement.canMove = true;
        }

        //pause
        if (Input.GetButtonDown("Cancel"))
        {
            uiMenu.Pause();
        }

        if (Input.GetButtonDown("Tab") && !talking)
        {
            uiMenu.TabPause();
        }

        if((Input.GetButtonDown("Cancel")) && paused)//if "Cancel" in any menu, unpause and leave all menus
        {
            uiMenu.Unpause();
            uiMenu.TabUnpause();
        }

        if (Input.GetButton("Interact") && !paused && !dead)
        {
            uiDialog.interact = true;
        }


    }


}
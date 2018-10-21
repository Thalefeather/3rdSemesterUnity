﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PauseManager : MonoBehaviour {

    [SerializeField] bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject tabMenu;

    // Use this for initialization
    void Start () {
        Unpause();
        TabUnpause();

    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Cancel") && isPaused == false)
        {
            isPaused = true;
            Pause();
        }
        else
        {
            if(Input.GetButtonDown("Cancel"))
            {
                isPaused = false;
                Unpause();
            }
        }

        if (Input.GetButtonDown("Tab") && isPaused == false)
        {
            Debug.Log("PRESSED TAB AND NOT PAUSED");
            isPaused = true;
            TabPause();
        }
        else
        {
            if (Input.GetButtonDown("Tab"))
            {
                Debug.Log("PRESSED TAB AND PAUSED");
                isPaused = false;
                TabUnpause();
            }
        }




    }

    public void Pause()
    {
        //bug where paused can still do normal commands, need to disable all inputs to solve, prolly have to create input manager
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void TabPause()
    {
        tabMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void TabUnpause()
    {
        tabMenu.SetActive(false);
        Time.timeScale = 1;
    }


}
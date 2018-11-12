using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PauseManager : MonoBehaviour {

    [SerializeField] bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject tabMenu;
    [Space]
    public SimpleHealthBar levelBar;
    public SimpleHealthBar walkingBar;
    public SimpleHealthBar defenseBar;
    public SimpleHealthBar rangedBar;
    public SimpleHealthBar meleeBar;
    
  

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
        updateAllBars();
        tabMenu.SetActive(true);
        Time.timeScale = 0; 
    }

    public void TabUnpause()
    {
        tabMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void updateAllBars()
    {
        GameObject PC = GameObject.Find("Player");

        var Z = PC.GetComponent<T_SkillTracker>().Player;
        levelBar.UpdateBar(Z[1], Z[2]);

        Z = PC.GetComponent<T_SkillTracker>().Walking;
        walkingBar.UpdateBar(Z[1], Z[2]);

        Z = PC.GetComponent<T_SkillTracker>().Defense;
        defenseBar.UpdateBar(Z[1], Z[2]);

        Z = PC.GetComponent<T_SkillTracker>().Ranged;
        rangedBar.UpdateBar(Z[1], Z[2]);

        Z = PC.GetComponent<T_SkillTracker>().Melee;
        meleeBar.UpdateBar(Z[1], Z[2]);


    }


}

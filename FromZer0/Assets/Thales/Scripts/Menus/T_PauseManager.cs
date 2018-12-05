using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PauseManager : MonoBehaviour {

    [SerializeField] bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject tabMenu;
    [SerializeField] GameObject deadMenu;
    [Space]
    public SimpleHealthBar levelBar;
    public SimpleHealthBar walkingBar;
    public SimpleHealthBar defenseBar;
    public SimpleHealthBar rangedBar;
    public SimpleHealthBar meleeBar;

    GameObject PC;

    [Space]
    public bool tabPaused = false;
    public bool paused = false;



    // Use this for initialization
    void Start () {
        Unpause();
        TabUnpause();
        PC = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (isPaused)
        {
            PC.GetComponent<T_Player_Inputs>().paused = true;
        }
        else
        {
            PC.GetComponent<T_Player_Inputs>().paused = false;
        }
    }

    public void Pause()//called on esc press
    {
        if (isPaused == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            paused = true;
        }
        else if(!tabPaused)
        {
            Unpause();
        }
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        paused = false;
    }

    public void TabPause()//called on tab press
    {
        if (isPaused == false)
        {
            updateAllBars();
            tabMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            tabPaused = true;
        }
        else if(!paused)
        {
            TabUnpause();
        }
    }

    public void TabUnpause()
    {
        tabMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        tabPaused = false;
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

    public void DeadPause()//called on DEAD
    {
        deadMenu.SetActive(!deadMenu.activeInHierarchy);
    }


}

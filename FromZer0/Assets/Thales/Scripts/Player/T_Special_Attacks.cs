using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Special_Attacks : MonoBehaviour {

    [SerializeField] float isActive = 0;//skill that is active (laser, heal, etc)
    [SerializeField] float useCounter = 0;
    float currentCDMax = 0;

    [SerializeField] float heal_healPerTick = 1;
    [SerializeField] float heal_tickLength = 0.1f;
    [SerializeField] float heal_totalTicks = 10;
    [SerializeField] float heal_cooldown = 5;
    [SerializeField] float heal_cost = 25;

    [SerializeField] GameObject skillLaserPrefab;
    [SerializeField] float laser_cooldown = 2;
    [SerializeField] float laser_cost = 50;

    [SerializeField] public Button HealButton;
    [SerializeField] public GameObject HealIcon;
    [SerializeField] public Button LaserButton;
    [SerializeField] public GameObject LaserIcon;

    public SimpleHealthBar CdBar;

    float spTotal;



    // Use this for initialization
    void Start()
    {
        HealButton.onClick.AddListener(delegate { setActive(0); });
        LaserButton.onClick.AddListener(delegate { setActive(1); });
    }

    // Update is called once per frame
    void Update()
    {
        useCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha1) && isActive==0)
        {
            isActive = 1;
            HealIcon.SetActive(false);
            LaserIcon.SetActive(true);
        }
        else
        if (Input.GetKeyDown(KeyCode.Alpha1) && isActive == 1)
        {
            isActive = 0;
            HealIcon.SetActive(true);
            LaserIcon.SetActive(false);
        }

        if (Input.GetButtonDown("Fire3") && useCounter >= currentCDMax && isActive == 0)
        {
            Heal();
        }

        if (Input.GetButtonDown("Fire3") && useCounter >= currentCDMax && isActive == 1)
        {
            Laser();
        }

        CdBar.UpdateBar(useCounter, currentCDMax);

    }
    void Heal()
    {
        if(checkIfEnoughSP(heal_cost))
        {
            //need to make this framerate independant
            float counter = 1;

            while (counter <= heal_totalTicks)
            {
                counter++;
                this.GetComponent<T_Health>().Heal(heal_healPerTick);
            }
            currentCDMax = heal_cooldown;
            useCounter = 0;
        }
    }

    void Laser()
    {
        if (checkIfEnoughSP(laser_cost))
        {
            GameObject laser = Instantiate(skillLaserPrefab, transform.position, Quaternion.Euler(0, 0, this.GetComponent<T_Player_Shooting>().angleOfMove())) as GameObject;
            currentCDMax = laser_cooldown;
            useCounter = 0;
        }
    }

    public void setActive(int value)
    {
        isActive = value;
    }

    bool checkIfEnoughSP(float cost)
    {
        var spTotal = this.gameObject.GetComponent<T_Health>().currentSP;
        if (cost <= spTotal)
        {
            this.gameObject.GetComponent<T_Health>().LoseSP(cost);
            return true;
        }
        else
        {
            return false;
            //play sound effect of not enough to use skill
        }
    }
}

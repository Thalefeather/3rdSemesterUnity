using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Special_Attacks : MonoBehaviour {

    [SerializeField] float isActive = 0;
    [SerializeField] float useCounter = 0;

    [SerializeField] float heal_healPerTick = 1;
    [SerializeField] float heal_tickLength = 0.1f;
    [SerializeField] float heal_totalTicks = 10;
    [SerializeField] float heal_cooldown = 5;
    
    [SerializeField] GameObject skillLaserPrefab;
    [SerializeField] float laser_cooldown = 2;

    [SerializeField] public Button HealButton;
    [SerializeField] public Button LaserButton;






    // Use this for initialization
    void Start()
    {
        HealButton.onClick.AddListener(delegate { setActive(0); });
        LaserButton.onClick.AddListener(delegate { setActive(1); });

    }

    // Update is called once per frame
    void Update()
    {
        useCounter -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha1) && isActive==0)
        {
            isActive = 1;
        }
        else
        if (Input.GetKeyDown(KeyCode.Alpha1) && isActive == 1)
        {
            isActive = 0;
        }

        if (Input.GetButtonDown("Fire3") && useCounter <= 0 && isActive == 0)
        {
            Heal();
        }

        if (Input.GetButtonDown("Fire3") && useCounter <= 0 && isActive == 1)
        {
            Laser();
        }

    }
    void Heal()
    {
        //need to make this framerate independant
        float counter = 1;

        while (counter <= heal_totalTicks)
        {
            counter++;
            this.GetComponent<T_Health>().Heal(heal_healPerTick);
        }

        useCounter = heal_cooldown;
    }

    void Laser()
    {
        GameObject laser = Instantiate(skillLaserPrefab, transform.position, Quaternion.Euler(0, 0, this.GetComponent<T_Player_Shooting>().angleOfMove())) as GameObject;
        useCounter = laser_cooldown;
    }

    public void setActive(int value)
    {
        isActive = value;
    }
}

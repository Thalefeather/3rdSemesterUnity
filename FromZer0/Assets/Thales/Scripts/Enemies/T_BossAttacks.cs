using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_BossAttacks : MonoBehaviour {

    [SerializeField] GameObject bossHorizontal;
    [SerializeField] GameObject meteorAttack;
    [SerializeField] bool useMeteor = false;
    float meteorCounter = 0;
    [SerializeField] float meteorDelay = 2;

    [SerializeField] float AP1Delay = 1.5f;

    [SerializeField] bool AP1 = false;
    [SerializeField] bool AP2 = false;

    // Use this for initialization
    void Start () {
        AttackPattern1(false);
       //setUseMeteor();
    }
	
	// Update is called once per frame
	void Update () {
        if(AP1)
        {
            AttackPattern1(false);
        }
        if(AP2)
        {
            AttackPattern2();
        }
    }

    void SideToSideLeftTo()
    {
        GameObject laser = Instantiate(bossHorizontal, transform.GetChild(1).position, Quaternion.identity);
    }

    void SideToSideRightTo()
    {
        GameObject laser = Instantiate(bossHorizontal, transform.GetChild(2).position, Quaternion.Euler(0, 0, 180));
    }

    void AttackPattern1(bool LeftRightLeft)//horizontal to horizontal
    {
        if(LeftRightLeft)
        {
            SideToSideLeftTo();
            Invoke("SideToSideRightTo", AP1Delay);
            Invoke("SideToSideLeftTo", AP1Delay*2);
        }
        else
        {
            SideToSideRightTo();
            Invoke("SideToSideLeftTo", AP1Delay);
            Invoke("SideToSideRightTo", AP1Delay * 2);
        }
    }

    void AttackPattern2()
    {
        useMeteor = true;
        meteorCounter = meteorCounter + Time.deltaTime;
    }

    void Meteor (Collider2D collision)
    {
        GameObject meteor = Instantiate(meteorAttack, collision.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transform.GetChild(3).gameObject.SetActive(true);//activates door when player enters boss room
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(useMeteor && meteorCounter >= meteorDelay && collision.tag == "Player")
        {
            Meteor(collision);
            meteorCounter = 0;
        }
    }




}

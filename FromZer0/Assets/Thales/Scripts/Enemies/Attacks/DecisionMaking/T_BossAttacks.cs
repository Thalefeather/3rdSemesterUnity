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

    float patternCounter = 4.5f;
    int meteorTotalAmountCounter = 0;

    [Space]
    public GameObject NPC;

    // Use this for initialization
    void Start () {
       //AttackPattern1(false);
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
            NPC.GetComponent<Dialog>().dialogueIndex = 5;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(useMeteor && meteorCounter >= meteorDelay && collision.tag == "Player" && meteorTotalAmountCounter<2)
        {
            Meteor(collision);
            meteorCounter = 0;
            meteorTotalAmountCounter++;

            if(meteorTotalAmountCounter>2)
            {
                useMeteor = false;
            }
        }

        if(collision.tag == "Player")
        {
            chooseAttack();
        }
        
    }

    private void chooseAttack()
    {
        
        float randomNumber;

        patternCounter = patternCounter + Time.deltaTime;
        if(patternCounter == 0 || patternCounter == 4)
        {
            Debug.Log("counter " + patternCounter);
        }
        
        if(patternCounter >= 5)
        {
            randomNumber = Random.Range(0,4);
            Debug.Log("randomNumber "+randomNumber);

            if(randomNumber == 0)
            {
                Debug.Log("attack choice 0");
                AttackPattern1(true);
                patternCounter = 0;
            }
            else if(randomNumber == 1)
            {
                Debug.Log("attack choice 1");
                AttackPattern1(false);
                patternCounter = 0;
            }
            else if (randomNumber == 2)
            {
                Debug.Log("attack choice 2");
                //AttackPattern2();
                AP2 = true;
                meteorTotalAmountCounter = 0;
                patternCounter = 0;
            }
            else if (randomNumber >= 3)
            {
                Debug.Log("attack choice 3");
                AttackPattern1(true);
                //AttackPattern2();
                AP2 = true;
                meteorTotalAmountCounter = 0;
                patternCounter = 0;
            }
        }
    }




}

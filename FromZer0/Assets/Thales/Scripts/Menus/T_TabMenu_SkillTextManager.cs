using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_TabMenu_SkillTextManager : MonoBehaviour {

    [SerializeField] Text PlayerLevel;
    [SerializeField] Text ScrapAmount;
    [SerializeField] Text HP;

    [SerializeField] Text WalkingLevel;
    [SerializeField] Text DefenseLevel;
    [SerializeField] Text RangedLevel;
    [SerializeField] Text MeleeLevel;
    GameObject Z;



    // Use this for initialization
    void Start () {
        Z = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        setValues();
    }

    void setValues()
    {
        var Player = Z.GetComponent<T_SkillTracker>().Player;
        PlayerLevel.text = Player[0].ToString();

        var Scrap = Z.transform.GetChild(1).GetComponent<T_CurrencyManager>().currentAmount;
        ScrapAmount.text = Scrap.ToString();

        var currentHP = Z.GetComponent<T_Health>().currentHealth;
        var totalHP = Z.GetComponent<T_Health>().maxHealth;

        HP.text = currentHP + "/" + totalHP;




        var Walking = Z.GetComponent<T_SkillTracker>().Walking;
        WalkingLevel.text = Walking[0].ToString();

        var Defense = Z.GetComponent<T_SkillTracker>().Defense;
        DefenseLevel.text = Defense[0].ToString();

        var Ranged = Z.GetComponent<T_SkillTracker>().Ranged;
        RangedLevel.text = Ranged[0].ToString();

        var Melee = Z.GetComponent<T_SkillTracker>().Melee;
        MeleeLevel.text = Melee[0].ToString();
    }
}

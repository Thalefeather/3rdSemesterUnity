using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_TabMenu_SkillTextManager : MonoBehaviour {

    [SerializeField] GameObject Pages;

    [Space]

    [SerializeField] Text PlayerLevel;
    [SerializeField] Text ScrapAmount;
    [SerializeField] Text PendingScrapText;
    [SerializeField] Text HP;
    [SerializeField] Text SP;
    [Space]
    [SerializeField] Text PlayerLevelBellow;
    [SerializeField] Text WalkingLevel;
    [SerializeField] Text DefenseLevel;
    [SerializeField] Text RangedLevel;
    [SerializeField] Text MeleeLevel;

    GameObject Z;



    // Use this for initialization
    void Start () {
        Z = GameObject.Find("Player");
        ChangeToPanel(0);
    }
	
	// Update is called once per frame
	void Update () {
        setValues();
    }

    void setValues()
    {
        var Player = Z.GetComponent<T_SkillTracker>().Player;
        PlayerLevel.text = Player[0].ToString();
        PlayerLevelBellow.text = Player[0].ToString();

        var Scrap = Z.transform.GetChild(1).GetComponent<T_CurrencyManager>().currentAmount;
        ScrapAmount.text = Scrap.ToString();

        PendingScrapText.text = PlayerPrefs.GetFloat("PendingScrap").ToString();

        var currentHP = Z.GetComponent<T_Health>().currentHealth;
        var totalHP = Z.GetComponent<T_Health>().maxHealth;

        HP.text = currentHP.ToString("F0") + "/" + totalHP.ToString("F0");
        SP.text = Z.GetComponent<T_Health>().currentSP.ToString("F0") + "/" + Z.GetComponent<T_Health>().maxSP.ToString("F0");



        var Walking = Z.GetComponent<T_SkillTracker>().Walking;
        WalkingLevel.text = Walking[0].ToString();

        var Defense = Z.GetComponent<T_SkillTracker>().Defense;
        DefenseLevel.text = Defense[0].ToString();

        var Ranged = Z.GetComponent<T_SkillTracker>().Ranged;
        RangedLevel.text = Ranged[0].ToString();

        var Melee = Z.GetComponent<T_SkillTracker>().Melee;
        MeleeLevel.text = Melee[0].ToString();
    }

    public void ChangeToPanel(int panel)
    {
        if (panel == 0)
        {
            Pages.transform.GetChild(0).gameObject.SetActive(true);
            Pages.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (panel == 1)
        {
            Pages.transform.GetChild(0).gameObject.SetActive(false);
            Pages.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}

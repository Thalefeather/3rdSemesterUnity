using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_CurrencyManager : MonoBehaviour {

    [SerializeField] public float currentAmount = 0;
    [SerializeField] float totalAmount = 999999;

	// Use this for initialization
	void Start () {
        currentAmount = PlayerPrefs.GetFloat("Scrap");
    }
	
	// Update is called once per frame
	void Update () {
        currentAmount = PlayerPrefs.GetFloat("Scrap");
    }

    public void earnCurrency(float amount)
    {
        //currentAmount = currentAmount + amount;

        PlayerPrefs.SetFloat("Scrap", currentAmount + amount);

        GameObject ScrapUI = GameObject.Find("EarnedScrapRepresentationManager");
        ScrapUI.GetComponent<T_EarnedScrapCanvas>().setValue(amount);

        Debug.Log("Earned " + amount+" Scrap");
    }
    
    public void loseCurrency(float amount)
    {
        //currentAmount = currentAmount - amount;

        PlayerPrefs.SetFloat("Scrap", currentAmount - amount);

        if (currentAmount <0)
        {
            currentAmount = 0;
        }
    }

    public bool checkIfEnough(float amount)
    {
        currentAmount = PlayerPrefs.GetFloat("Scrap");

        if (currentAmount - amount >= 0)
        {
            return true;
        }
        else
            return false;
    }

}

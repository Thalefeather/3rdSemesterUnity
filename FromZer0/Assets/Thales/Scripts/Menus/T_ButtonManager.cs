using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T_ButtonManager : MonoBehaviour {

    public Item LaserGun;
    public Item GunParts;

    public Item Sword;
    public Item SwordParts;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void RestartCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Craft(int value)
    {
        GameObject Inv = GameObject.Find("Inventory");
        GameObject Tinv = GameObject.Find("TInventory");
        if (value == 0)
        {
            if(Inv.GetComponent<PInventory>().CheckIfItemIsInInventory(GunParts) && Tinv.GetComponent<T_CurrencyManager>().checkIfEnough(500))
            {
                Inv.GetComponent<PInventory>().RemoveItem(GunParts);
                Inv.GetComponent<PInventory>().AddItem(LaserGun);
                Tinv.GetComponent<T_CurrencyManager>().loseCurrency(500);
            }
        }
        if(value == 1)
        {
            if (Inv.GetComponent<PInventory>().CheckIfItemIsInInventory(SwordParts) && Tinv.GetComponent<T_CurrencyManager>().checkIfEnough(250))
            {
                Inv.GetComponent<PInventory>().RemoveItem(SwordParts);
                Inv.GetComponent<PInventory>().AddItem(Sword);
                Tinv.GetComponent<T_CurrencyManager>().loseCurrency(250);
            }
        }
    }

}

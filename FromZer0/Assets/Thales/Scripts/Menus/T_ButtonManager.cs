using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T_ButtonManager : MonoBehaviour {

    public Item[] items;

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
            if(Inv.GetComponent<PInventory>().CheckIfItemIsInInventory(items[1]) && Tinv.GetComponent<T_CurrencyManager>().checkIfEnough(500))//laser gun crafting
            {
                Inv.GetComponent<PInventory>().RemoveItem(items[1]);
                Inv.GetComponent<PInventory>().AddItem(items[0]);
                Tinv.GetComponent<T_CurrencyManager>().loseCurrency(500);
            }
        }
        if(value == 1)
        {
            if (Inv.GetComponent<PInventory>().CheckIfItemIsInInventory(items[3]) && Tinv.GetComponent<T_CurrencyManager>().checkIfEnough(250))//sword crafting
            {
                Inv.GetComponent<PInventory>().RemoveItem(items[3]);
                Inv.GetComponent<PInventory>().AddItem(items[2]);
                Tinv.GetComponent<T_CurrencyManager>().loseCurrency(250);
            }
        }
    }

    public void Buy(int value)
    {
        GameObject Inv = GameObject.Find("Inventory");
        GameObject Tinv = GameObject.Find("TInventory");
        if (value == 0)
        {
            if (Tinv.GetComponent<T_CurrencyManager>().checkIfEnough(500))
            {
                Inv.GetComponent<PInventory>().AddItem(items[0]);
                Tinv.GetComponent<T_CurrencyManager>().loseCurrency(500);
            }
        }
        if (value == 1)
        {
            if (Tinv.GetComponent<T_CurrencyManager>().checkIfEnough(350))
            {
                Inv.GetComponent<PInventory>().AddItem(items[2]);
                Tinv.GetComponent<T_CurrencyManager>().loseCurrency(350);
            }
        }
        if (value == 2)
        {
            if (Tinv.GetComponent<T_CurrencyManager>().checkIfEnough(200))
            {
                Inv.GetComponent<PInventory>().AddItem(items[4]);
                Tinv.GetComponent<T_CurrencyManager>().loseCurrency(200);
            }
        }
        if (value == 3)
        {
            if (Tinv.GetComponent<T_CurrencyManager>().checkIfEnough(100))
            {
                Inv.GetComponent<PInventory>().AddItem(items[3]);
                Tinv.GetComponent<T_CurrencyManager>().loseCurrency(100);
            }
        }


    }

}

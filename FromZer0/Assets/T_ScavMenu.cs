using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_ScavMenu : MonoBehaviour {
    public GameObject modelSelectionMenu;
    public GameObject missionSelectionMenu;
    public GameObject scavangersMenu;
    [Space]
    public GameObject scavSlot1;
    public GameObject scavSlot2;
    [Space]
    public T_Scav scav0;
    public T_Scav scav1;
    public T_Scav scav2;
    public T_Scav scav3;
    [Space]
    public T_Mission mission1;
    public T_Mission mission2;
    [Space]
    [SerializeField] Text Model1;
    [SerializeField] Text Level1;
    [SerializeField] Text Status1;
    [SerializeField] Image Icon1;
    [Space]
    [SerializeField] Text Model2;
    [SerializeField] Text Level2;
    [SerializeField] Text Status2;
    [SerializeField] Image Icon2;


    int scavSlotToChooseMission = 0;

    int amountOfScavsOwned = 0;
    float[] buildCost;
    GameObject PC;

    bool slot0mission = false;
    bool slot1mission = false;
    float counter0 = 0;
    float counter1 = 0;
    int slot0CurrentMission = 0;
    int slot1CurrentMission = 0;




    // Use this for initialization
    void Start () {
        PC = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        runMissionUpdate();

    }

    //set actives
    public void openModelSelectionMenu()
    {
        modelSelectionMenu.SetActive(true);
    }

    public void closeModelSelectionMenu()
    {
        modelSelectionMenu.SetActive(false);
    }

    public void openMissionSelectionMenu(int ID)
    {
        missionSelectionMenu.SetActive(true);
        scavSlotToChooseMission = ID;
    }

    public void closeMissionSelectionMenu()
    {
        missionSelectionMenu.SetActive(false);
        scavSlotToChooseMission = 0;
    }

    public void openScavangersMenu()
    {
        scavangersMenu.SetActive(true);
    }

    public void closeScavangersMenu()
    {
        scavangersMenu.SetActive(false);
    }

    //end of set actives


    public void selectModelToBuild(int model)//cost deduction isnt working, null exception, prolly not finding player
    {
        if(model == 0 /*&& PC.transform.GetChild(2).GetComponent<T_CurrencyManager>().checkIfEnough(buildCost[0]) */)
        {
            //build M05-Q2
            buildModel(model);
            //PC.transform.GetChild(2).GetComponent<T_CurrencyManager>().loseCurrency(buildCost[0]);
            closeModelSelectionMenu();
        }
        else
        if (model == 1 /*&& PC.transform.GetChild(2).GetComponent<T_CurrencyManager>().checkIfEnough(buildCost[1])*/)
        {
            //build ShootyMcshoot
            buildModel(model);
            //PC.transform.GetChild(2).GetComponent<T_CurrencyManager>().loseCurrency(buildCost[1]);
            closeModelSelectionMenu();
        }
        else
        if (model == 2 /*&& PC.transform.GetChild(2).GetComponent<T_CurrencyManager>().checkIfEnough(buildCost[2]) */)
        {
            //build BIG M05-Q2
            buildModel(model);
            //PC.transform.GetChild(2).GetComponent<T_CurrencyManager>().loseCurrency(buildCost[2]);
            closeModelSelectionMenu();
        }
        else
        if (model == 3 /*&& PC.transform.GetChild(2).GetComponent<T_CurrencyManager>().checkIfEnough(buildCost[3]) */)
        {
            //build BOSS BOI
            buildModel(model);
            //PC.transform.GetChild(2).GetComponent<T_CurrencyManager>().loseCurrency(buildCost[3]);
            closeModelSelectionMenu();
        }
    }

    private void initiateBuildCost()
    {
        buildCost[0] = 100;
        buildCost[1] = 200;
        buildCost[2] = 350;
        buildCost[3] = 750;
    }

    private void buildModel(int model)
    {
        if (amountOfScavsOwned == 0)//build to scav 1 panel
        {
            if (model == 0)
            {
                Model1.text = scav0.ModelName.ToString();
                Level1.text = scav0.Level.ToString();
                Status1.text = scav0.Status.ToString();
            }
            if (model == 1)
            {
                Model1.text = scav1.ModelName.ToString();
                Level1.text = scav1.Level.ToString();
                Status1.text = scav1.Status.ToString();
            }
            if (model == 2)
            {
                Model1.text = scav2.ModelName.ToString();
                Level1.text = scav2.Level.ToString();
                Status1.text = scav2.Status.ToString();
            }
            if (model == 3)
            {
                Model1.text = scav3.ModelName.ToString();
                Level1.text = scav3.Level.ToString();
                Status1.text = scav3.Status.ToString();
            }
            scavSlot1.SetActive(true);
        }
        if (amountOfScavsOwned == 1)//build to scav 2 panel
        {
            if (model == 0)
            {
                Model2.text = scav0.ModelName.ToString();
                Level2.text = scav0.Level.ToString();
                Status2.text = scav0.Status.ToString();
            }
            if (model == 1)
            {
                Model2.text = scav1.ModelName.ToString();
                Level2.text = scav1.Level.ToString();
                Status2.text = scav1.Status.ToString();
            }
            if (model == 2)
            {
                Model2.text = scav2.ModelName.ToString();
                Level2.text = scav2.Level.ToString();
                Status2.text = scav2.Status.ToString();
            }
            if (model == 3)
            {
                Model2.text = scav3.ModelName.ToString();
                Level2.text = scav3.Level.ToString();
                Status2.text = scav3.Status.ToString();
            }
            scavSlot2.SetActive(true);
        }
        amountOfScavsOwned++;
    }

    public void sendOnMission(int mission)
    {
        if(scavSlotToChooseMission == 0)
        {
            if(mission == 0)
            {
                Status1.text = "On Mission 1!";
                slot0mission = true;
                closeMissionSelectionMenu();
                counter0 = mission1.TimeToComplete;
                slot0CurrentMission = mission;
            }
            if (mission == 1)
            {
                Status1.text = "On Mission 2!";
                slot0mission = true;
                closeMissionSelectionMenu();
                counter0 = mission2.TimeToComplete;
                slot0CurrentMission = mission;
            }
        }
        if (scavSlotToChooseMission == 1)
        {
            if (mission == 0)
            {
                Status2.text = "On Mission 1!";
                slot1mission = true;
                closeMissionSelectionMenu();
                counter1 = mission1.TimeToComplete;
                slot1CurrentMission = mission;
            }
            if (mission == 1)
            {
                Status2.text = "On Mission 2!";
                slot1mission = true;
                closeMissionSelectionMenu();
                counter1 = mission2.TimeToComplete;
                slot1CurrentMission = mission;
            }
        }
    }
    private void runMissionUpdate()
    {
        if(slot0mission == true)
        {
            if (counter0 >= 0)
            {
                counter0 -= Time.deltaTime;
                Status1.text = "Time Left: "+counter0.ToString("0");
            }
            if (counter0 < 0)
            {
                //completeMission
                Status1.text = "Ready";
                earnReward(slot0CurrentMission);
                slot0CurrentMission = 0;
                slot0mission = false;
            }
        }
        if (slot1mission == true)
        {
            if (counter1 >= 0)
            {
                counter1 -= Time.deltaTime;
                Status2.text = "Time Left: " + counter1.ToString("0");
            }
            if (counter1 < 0)
            {
                //completeMission
                Status2.text = "Ready";
                earnReward(slot1CurrentMission);
                slot1CurrentMission = 0;
                slot1mission = false;
            }
        }
    }

    private void earnReward(int fromThisMission)
    {
        GameObject PC_Inventory = GameObject.Find("TInventory");

        if(fromThisMission == 0)
        {
            PC_Inventory.GetComponent<T_CurrencyManager>().earnCurrency(mission1.ScrapReward);
        }
        if(fromThisMission == 1)
        {
            PC_Inventory.GetComponent<T_CurrencyManager>().earnCurrency(mission2.ScrapReward);
        }
    }

   
}

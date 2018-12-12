using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReward : MonoBehaviour {

    public GameObject reward;
    public GameObject Inventory;
    public GameObject sign;
    public Item questItem;
    public bool rewardGiven = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!rewardGiven && this.GetComponent<Dialog>().dialogueIndex == 6)
        {
            Instantiate(reward, transform.position, Quaternion.identity);
            rewardGiven = true;
            Inventory.GetComponent<PInventory>().RemoveItem(questItem);
            sign.GetComponent<Dialog>().dialogueIndex++;
        }
		
	}
}

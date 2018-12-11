using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_LootTable : MonoBehaviour {

    [System.Serializable]
    public class DropCurrency
    {
        public string name;
        public GameObject item;
        public int dropChance;
    }

    public List<DropCurrency> LootTable = new List<DropCurrency>();
    //public DropCurrency bestDrop;
    public int bestDropIndex = -1;

    private void Start()
    {
        CalculateLoot();
    }

    public void CalculateLoot()
    {
        for (int i = 0; i < LootTable.Count; i++)
        {
            
            int dropNumber = Random.Range(0, 101);
            Debug.Log("Random Number" + dropNumber);

            if (LootTable[i].dropChance >= dropNumber)
            {
                /*if(bestDrop.item == null)
                 {
                     bestDrop.name = LootTable[i].name;
                     bestDrop.item = LootTable[i].item;
                     bestDrop.dropChance = LootTable[i].dropChance;
                 }
                else if(LootTable[i].dropChance < bestDrop.dropChance)
                 {
                     bestDrop.name = LootTable[i].name;
                     bestDrop.item = LootTable[i].item;
                     bestDrop.dropChance = LootTable[i].dropChance;
                 }
                 Debug.Log("BEST ITEM: " + bestDrop.name);*/
                Debug.Log("MATCH");
                if(bestDropIndex == -1)
                {
                    bestDropIndex = i;
                }
                else if(LootTable[i].dropChance < LootTable[bestDropIndex].dropChance)
                 {
                    bestDropIndex = i;
                }

                
            }
        }
    }

    public void spawnBestDrop()
    {
        if (bestDropIndex != -1)
        {
            Debug.Log("SPAWNED");
            Instantiate(LootTable[bestDropIndex].item, this.transform.position, Quaternion.identity);
        }
    }
}

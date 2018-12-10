using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_ItemDrop : MonoBehaviour {

    public GameObject Inv;
    public GameObject Tinv;
    [Space]
    public Item item;
    public EquippableItem equipment;
    public float scrap = 0;


    private void Start()
    {
        //Inv = GameObject.Find("Inventory");
        //Tinv = GameObject.Find("TInventory");

        

        if(equipment != null)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
        }
        if(scrap > 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (item != null)
            {
                if (Inv.GetComponent<PInventory>().AddItem(item))
                    Destroy(this.gameObject);
            }
            if (equipment != null)
            {
                if (Inv.GetComponent<PInventory>().AddItem(equipment))
                    Destroy(this.gameObject);
            }
            if (scrap > 0)
            {
                Tinv.GetComponent<T_CurrencyManager>().earnCurrency(scrap);
                Destroy(this.gameObject);
            }
        }
    }
}

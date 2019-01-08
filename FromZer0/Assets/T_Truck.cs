using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Truck : MonoBehaviour {

    public GameObject exclamation;
    public T_Player_Inputs PCInputs;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && this.gameObject.transform.tag != "ScrapCollector")
        {
            exclamation.SetActive(true);
            PCInputs.touchingTeleporter = true;
        }
        else
        {
            exclamation.SetActive(true);
            PCInputs.touchingCollector = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            exclamation.SetActive(false);
            PCInputs.touchingTeleporter = false;
            PCInputs.touchingCollector = false;
        }
    }
}

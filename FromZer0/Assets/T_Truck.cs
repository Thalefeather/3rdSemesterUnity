using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Truck : MonoBehaviour {

    public GameObject exclamation;
    public T_Player_Inputs PCInputs;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            exclamation.SetActive(true);
            PCInputs.touchingTeleporter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            exclamation.SetActive(false);
            PCInputs.touchingTeleporter = false;
        }
    }
}

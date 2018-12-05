using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {

    T_DialogManager manager;
    public string[] sentences;

    //tests for dialogue that can change! have idea on how to implement but not cleanly. leave for now.
    /*public string[][] DialogueOptions;
    public int currentDialogueOption;
    */



    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("UIManagers").transform.GetChild(3).GetComponent<T_DialogManager>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)//if dialog changing is added will have bug where dialog only changes once player leaves hitbox and comesback
    {
        if(collision.tag == "Player")
        {
            manager.touchingNPC = true;
            manager.sentences = sentences;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            manager.touchingNPC = false;
        }
    }

}

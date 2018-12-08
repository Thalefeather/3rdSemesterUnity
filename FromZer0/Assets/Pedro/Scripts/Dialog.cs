using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {
    [System.Serializable]
    public class MultiDimensionalString
    {
        public string[] Sentences;
    }

    T_DialogManager manager;
    public int index = 0;
    public MultiDimensionalString[] Dialogue;



   




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
            manager.sentences = Dialogue[index].Sentences;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            manager.touchingNPC = false; 
        }
    }

    public void changeDialogueIndexTo (int value)
    {
        index = value;
    }

}

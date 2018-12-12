using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {
    [System.Serializable]
    public class DialogueOptionsClass
    {
        public string Description;
        public string[] Sentences;
        public bool triggerConversation;
        public int increaseIndexTo = -1;
        [Space]
        public string dialogueChoice1Text = "";
        public int dialogueChoice1toIndex = 0;
        [Space]
        public string dialogueChoice2Text = "";
        public int dialogueChoice2toIndex = 0;
        [Space]
        public string dialogueChoice3Text = "";
        public int dialogueChoice3toIndex = 0;

    }

    T_DialogManager manager;
    public int dialogueIndex = 0;
    public List<DialogueOptionsClass> DialogueOptions = new List<DialogueOptionsClass>();



   




    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("UIManagers").transform.GetChild(3).GetComponent<T_DialogManager>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            manager.touchingNPC = true;
            manager.sentences = DialogueOptions[dialogueIndex].Sentences;
            manager.talkingToThisGuy = this.GetComponent<Dialog>();
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

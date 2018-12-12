using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class T_DialogManager : MonoBehaviour {

    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject DialogBoxMenu;

    [SerializeField] GameObject conversastionAvailableIcon;
    [Space]
    [SerializeField] GameObject DialogueOptions;
    [SerializeField] Text choice1;
    [SerializeField] Text choice2;
    [SerializeField] Text choice3;



    public string[] sentences;
    private int index=0;
    public float typingSpeed;

    [Space]

    public bool endOfSentence = false;
    public bool speedUpTyping = false;
    public bool inConversation = false;
    public bool touchingNPC = false;

    [Space]

    public Dialog talkingToThisGuy;
    public bool interact = false;
    GameObject PC;
    


    // Use this for initialization
    void Start()
    {
        PC = GameObject.Find("Player");
    }

    void Update()
    {
        if(touchingNPC)//set touchingNPC in player input manager to make fire1 contextual talk or attack
        {
            PC.GetComponent<T_Player_Inputs>().touchingNpc = true;
        }
        else
        {
            PC.GetComponent<T_Player_Inputs>().touchingNpc = false;
        }

        //activate conversation
        if (interact && touchingNPC && inConversation == false)
        {
            StartCoroutine(Type());
            DialogBoxMenu.SetActive(true);
            inConversation = true;
            interact = false;
            PC.GetComponent<T_Player_Inputs>().talking = true;
        }
        //jump to next sentence
        else if(interact && endOfSentence && inConversation == true)
        {
            NextSentence();
            endOfSentence = false;
            interact = false;
        }
        else if (interact && endOfSentence == false && inConversation == true)
        {
            speedUpTyping = !speedUpTyping;
            interact = false;
        }

        //set continue button  active
        if (textDisplay.text == sentences[index] && sentences[index]!=null)
        {
            continueButton.SetActive(true);
            endOfSentence = true;
        }
        if (touchingNPC && inConversation == false)
        {
            conversastionAvailableIcon.SetActive(true);
        }
        else
        {
            conversastionAvailableIcon.SetActive(false);
        }

        interact = false;

    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            if (speedUpTyping == false)
                yield return new WaitForSeconds(typingSpeed);
            else
                yield return new WaitForSeconds(typingSpeed / 3);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else//End of conversation
        {            
            /*textDisplay.text = ""; //ORIGINAL CODE BEFORE ALL THE STUFF BELOW
            continueButton.SetActive(false);
            DialogBoxMenu.SetActive(false);
            inConversation = false;
            index = 0;
            PC.GetComponent<T_Player_Inputs>().talking = false;
            if (talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].increaseIndexTo != -1)//checks if the guy im talking to's current sentence wants to change to another sentence tha
            {
                talkingToThisGuy.dialogueIndex = talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].increaseIndexTo;
            }*/

            textDisplay.text = "";
            index = 0;
            
            if(talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].triggerConversation)
            {
                continueButton.SetActive(false);

                choice1.text = talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].dialogueChoice1Text;
                choice2.text = talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].dialogueChoice2Text;
                choice3.text = talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].dialogueChoice3Text;

                DialogueOptions.SetActive(true);
            }
            else if(talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].increaseIndexTo != -1)//checks if the guy im talking to's current sentence wants to change to another sentence then does it
            {
                talkingToThisGuy.dialogueIndex = talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].increaseIndexTo;

                continueButton.SetActive(false);
                DialogBoxMenu.SetActive(false);
                inConversation = false;
                PC.GetComponent<T_Player_Inputs>().talking = false;
            }
            else
            {
                continueButton.SetActive(false);
                DialogBoxMenu.SetActive(false);
                inConversation = false;
                PC.GetComponent<T_Player_Inputs>().talking = false;
            }


        }

        speedUpTyping = false;
    }

    /*public void GetSentence(Collider2D collision)
    {
        sentences = collision.GetComponent<T_DialogManager>().sentences;
    }

    public void activateConversation()
    {
        //activate conversation
        if (touchingNPC && inConversation == false)
        {
            StartCoroutine(Type());
            DialogBoxMenu.SetActive(true);
            inConversation = true;
        }
    }

    public void jumpSentence()
    {
        if (Input.GetKeyDown(KeyCode.F) && endOfSentence && inConversation == true)
        {
            NextSentence();
            endOfSentence = false;
        }
        else if (Input.GetKeyDown(KeyCode.F) && endOfSentence == false && inConversation == true)
        {
            speedUpTyping = !speedUpTyping;
        }
    }

    public void toggleSpeedUpTyping()
    {
            speedUpTyping = !speedUpTyping;
    }

    public void setContinueButtonActive()
    {
        //set continue button  active
        if (textDisplay.text == sentences[index] && sentences[index] != null)
        {
            continueButton.SetActive(true);
            endOfSentence = true;
        }
    }*/

    public void DialogOptionChosen(int value)
    {
        DialogueOptions.SetActive(false);

        if(value == 1)
        {
            talkingToThisGuy.dialogueIndex = talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].dialogueChoice1toIndex;
            //StartCoroutine(Type());
            //NextSentence();
            //interact = true;
        }
        if (value == 2)
        {
            talkingToThisGuy.dialogueIndex = talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].dialogueChoice2toIndex;
            //StartCoroutine(Type());
            //NextSentence();
            //interact = true;
        }
        if (value == 3)
        {
            talkingToThisGuy.dialogueIndex = talkingToThisGuy.DialogueOptions[talkingToThisGuy.dialogueIndex].dialogueChoice3toIndex;
            //StartCoroutine(Type());
            //NextSentence();
            //interact = true;
        }

        textDisplay.text = "";
        continueButton.SetActive(false);
        DialogBoxMenu.SetActive(false);
        inConversation = false;
        index = 0;
        PC.GetComponent<T_Player_Inputs>().talking = false;

        Invoke("setInteractToTrue", 0.1f);
        


    }

    private void setInteractToTrue()
    {
        interact = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class T_DialogManager : MonoBehaviour {

    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject DialogBoxMenu;

    [SerializeField] GameObject conversastionAvailableIcon;


    public string[] sentences;
    private int index=0;
    public float typingSpeed;

    [Space]

    public bool endOfSentence = false;
    public bool speedUpTyping = false;
    public bool inConversation = false;
    public bool touchingNPC = false;

    [Space]

    public bool interact = false;
    GameObject PC;


    // Use this for initialization
    void Start()
    {
        PC = GameObject.Find("Player");
    }

    void Update()
    {
        //activate conversation
        if (interact && touchingNPC && inConversation == false)
        {
            StartCoroutine(Type());
            DialogBoxMenu.SetActive(true);
            inConversation = true;
            interact = false;
            PC.GetComponent<T_Player_Inputs>().talking = true;
        }
        //jump sentence
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
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            DialogBoxMenu.SetActive(false);
            inConversation = false;
            index = 0;
            PC.GetComponent<T_Player_Inputs>().talking = false;
        }

        speedUpTyping = false;
    }

    public void GetSentence(Collider2D collision)
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
    }

}

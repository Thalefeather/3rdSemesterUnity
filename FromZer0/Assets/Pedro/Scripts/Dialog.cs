using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public Collider2D Player;
    public Collider2D MrTalkingDude;

    [SerializeField] GameObject DialogBoxMenu;
    

    
	// Use this for initialization
	void Start () {
    }

    void Update()
    {
        //activate conversation
        if (Player.IsTouching(MrTalkingDude))
        {
            StartCoroutine(Type());
            MrTalkingDude.GetComponent<CircleCollider2D>().enabled = false;
        }
        
        //jump sentence
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextSentence();
        }

        //set continue button  active
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }

       
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
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
        }   

    }

}

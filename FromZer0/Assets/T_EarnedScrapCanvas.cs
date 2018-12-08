using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_EarnedScrapCanvas : MonoBehaviour {

    [SerializeField] Text AmountOfScrap;
    [SerializeField] Text PlusSign;
    [SerializeField] Image Cog;
    [Space]
    public float alphaCounter = 0;
    public float alphaCounterTimeDivider = 100;
    [Space]
    public float timeBeforeFadingCounter = 0;
    public float timeBeforeFading = 2;
    [Space]
    public float totalAmount = 0;



    private void Start()
    {
        var tempColor = AmountOfScrap.color;
        tempColor.a = 0f;

        AmountOfScrap.color = tempColor;
        PlusSign.color = tempColor;
        Cog.color = tempColor;
    }

    private void Update()
    {
        var tempColor = AmountOfScrap.color;
      
        timeBeforeFadingCounter = timeBeforeFadingCounter - Time.deltaTime;

        if(timeBeforeFadingCounter <= 0)
        {
            alphaCounter = alphaCounter - Time.deltaTime / alphaCounterTimeDivider;

            tempColor.a = alphaCounter;

            AmountOfScrap.color = tempColor;
            PlusSign.color = tempColor;
            Cog.color = tempColor;

            if (alphaCounter <= 0)
            {
                totalAmount = 0;
            }
        }
        else
        {
            tempColor.a = 1f;
            alphaCounter = 1;

            AmountOfScrap.color = tempColor;
            PlusSign.color = tempColor;
            Cog.color = tempColor;
        }
    }


    public void setValue (float amount)
    {
        totalAmount += amount;
        timeBeforeFadingCounter = timeBeforeFading;

        AmountOfScrap.text = totalAmount.ToString("F0");
    }




}

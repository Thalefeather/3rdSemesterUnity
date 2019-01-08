using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;


public class QrMaker : MonoBehaviour {

    private enum State { Start, Update }
    private State state;
    private string ID;
    
    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
    //256
    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    public void OnGUI()
    {

                Texture2D myQR = generateQR(ID);
                if (GUI.Button(new Rect(0, 0, 256, 256), myQR, GUIStyle.none))
                {
            
                    Application.OpenURL("https://padcaa.itch.io/from-zer0");
                }

        }
    
    private void Start()
    {
        ID = PlayerPrefs.GetString("ID");
        Debug.Log(ID);
    }







}

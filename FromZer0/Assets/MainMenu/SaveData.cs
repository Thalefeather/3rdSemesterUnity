using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

    [SerializeField]
    private GameApi _api;

    private string ID;
    private float Scrap, PendingScrap;


    void Awake()
    {
        if (_api == null)
            _api = FindObjectOfType<GameApi>();

        if (_api == null)
            Debug.LogError("'Api' field must be set!");
    }

    public void OnSaveDataButtonClick()
    {
        Scrap = PlayerPrefs.GetFloat("Scrap");
        PendingScrap = PlayerPrefs.GetFloat("PendingScrap");

        ID = PlayerPrefs.GetString("ID");
        _api.SaveData(ID, Scrap.ToString(), PendingScrap.ToString(), (bool error, string data) =>
        {
            if (error)
            {
                Debug.LogError("Error:" + data);
            }

            else
            {
                Debug.Log("Response:" + data);
            }
                
        });
    }
}

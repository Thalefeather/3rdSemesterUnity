using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLogic : MonoBehaviour
{
    [SerializeField]
    private GameApi _api;

    [SerializeField]
    private string _dataForSave = string.Empty;

    [SerializeField]
    private InputField _usernameField, _passwordField;

    [HideInInspector]
    public string GlobalPlayerName, GlobalPlayerID;
    [HideInInspector]
    static  float GlobalPlayerScrap;

    private string CheckID, CheckName;
    private float CheckScrap;

    // Use this for initialization
    void Awake()
    {
        if (_api == null)
            _api = FindObjectOfType<GameApi>();

        if (_api == null)
            Debug.LogError("'Api' field must be set!");
    }

    private void Start()
    {
       
        CheckID = PlayerPrefs.GetString("ID");
        CheckName = PlayerPrefs.GetString("Name");
      
        if(CheckID==null || CheckName==null || CheckID=="" || CheckName=="")
        {
            Debug.Log("No data saved yet");
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OnRegisterButtonClick()
    {
        _api.Register(_usernameField.text, _passwordField.text, (bool error, string data) =>
        {
            if (error) {
                Debug.LogError("Error:" + data);
            }
                
            else{
                Debug.Log("Response:" + data);
            }
                
        });
    }




    public void OnLoginButtonClick()
    {
        _api.Login(_usernameField.text, _passwordField.text, (bool error, string data) =>
        {
            if (error)
            {
                Debug.LogError("Error:" + data);
            }
            else
            {


                Debug.Log("Response Login:" + data);

                var json = SimpleJSON.JSON.Parse(data);

                var account = json["account"];

                GlobalPlayerName = account["username"];

                GlobalPlayerID = account["_id"];

                var accountData = account["data"];

                GlobalPlayerScrap = accountData["coins"].AsFloat;

                PlayerPrefs.SetString("ID", GlobalPlayerID);
                PlayerPrefs.SetString("Name", GlobalPlayerName);
                PlayerPrefs.SetFloat("Scrap", GlobalPlayerScrap);

                // Debug.Log("Player name:" + GlobalPlayerName);
                // Debug.Log("Player ID:" + GlobalPlayerID);
                //Debug.Log("Player Scrap:" + GlobalPlayerScrap);

                SceneManager.LoadScene(1);
            }
        });
    }




    public void OnGetDataButtonClick()
    {
        _api.GetData(_usernameField.text, _passwordField.text, (bool error, string data) =>
        {
            if (error)
                Debug.LogError("Error:" + data);
            else
            {
                Debug.Log("Response:" + data);

                //Example of using JSON parser 'SimpleJSON' http://wiki.unity3d.com/index.php/SimpleJSON
                //try parse json and get field 'account'->'data'

                var json = SimpleJSON.JSON.Parse(data);

                var account = json["account"];

                var accountData = account["data"];

                if (accountData["coins"] != null)
                {
                    var coins = accountData["coins"].AsInt;

                    Debug.Log("get coins:" + coins);
                }
                else
                {
                    Debug.Log("No field 'account.data.coins'!");
                }
            }
        });
    }

   
}

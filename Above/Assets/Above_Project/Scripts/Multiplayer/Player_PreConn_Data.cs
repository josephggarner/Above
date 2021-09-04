using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_PreConn_Data : Singleton<Player_PreConn_Data>
{
    //public static Player_PreConn_Data instance { get; private set; }

    [SerializeField]
    public string selectedName { get; private set; }
    [SerializeField]
    public GameObject selectedChar;
    [SerializeField]
    private TMP_InputField nameField;

    //[SerializeField]
    //private bool connectionFailed = false;

    // Start is called before the first frame update


     public override void Start()
    {
        selectedName = "Anon";
        if (Scene_Manager.CurrentSceneName == "Multiplayer_Login")
        {
            selectedChar = SwitchCharacterPlatform.Instance.ReturnSelectedChar();
        }
    }

    public void SetName()
    {
        if(nameField.text == "") { selectedName = "Anon"; } else
        {
            selectedName = nameField.text;
        }
        
    }

    public void SetCharacter()
    {
        if (Scene_Manager.CurrentSceneName == "Multiplayer_Login")
        {
            selectedChar = SwitchCharacterPlatform.Instance.ReturnSelectedChar();
        }
    }


    // Update is called once per frame
    public override void Update()
    {
        
    }



}

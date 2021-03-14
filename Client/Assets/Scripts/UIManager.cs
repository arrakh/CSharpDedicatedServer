using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    public GameObject startmenu;
    public TMP_InputField usernameField;

    public void ConnectToServer()
    {
        startmenu.SetActive(false);
        usernameField.interactable = false;
        Client.Instance.ConnectToServer();

    }
}

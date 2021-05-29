using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    private static UImanager instance;
    public static UImanager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] GameObject NpcChat;
    private void Awake()
    {
        instance = this;
    }

    public void OnChat(bool isOn)
    {
        NpcChat.SetActive(isOn);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

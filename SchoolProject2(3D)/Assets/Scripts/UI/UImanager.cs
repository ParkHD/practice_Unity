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

    [SerializeField] GameObject npcChat;
    [SerializeField] GameObject interaction;
    [SerializeField] GameObject cross;
    public GameObject NpcChat
    {
        get { return npcChat; }
    }


    private void Awake()
    {
        instance = this;
    }

    public void OnChat(bool isOn)
    {
        npcChat.SetActive(isOn);
        interaction.SetActive(!isOn);
        cross.SetActive(!isOn);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

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

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            StartCoroutine(Switching(child.gameObject));
        }
    }

    public void OnChat(bool isOn)
    {
        npcChat.SetActive(isOn);
        interaction.SetActive(!isOn);
        cross.SetActive(!isOn);
        OnCursor(isOn);
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }
    public void ConstraingUI(bool isOn)
    {
        interaction.SetActive(!isOn);
        cross.SetActive(!isOn);
    }
    public void OnCursor(bool isOn)
    {
        Cursor.lockState = isOn ? CursorLockMode.None : CursorLockMode.Locked ;
    }
    IEnumerator Switching(GameObject target)
    {
        bool isBefore = target.activeSelf;
        target.SetActive(true);
        yield return new WaitForEndOfFrame(); // 1프레임을 기다린다.
        target.SetActive(isBefore);
    }
}

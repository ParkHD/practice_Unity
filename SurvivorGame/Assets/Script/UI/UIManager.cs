using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject invenUI;

    public void ShowInven()
    {
        bool isInvenOpen = invenUI.activeSelf;
        Cursor.lockState = isInvenOpen ? CursorLockMode.Locked : CursorLockMode.None;
        invenUI.SetActive(!isInvenOpen);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogUI : MonoBehaviour
{
    ItemLogSlot[] itemLog;

    private void Awake()
    {
        itemLog = GetComponentsInChildren<ItemLogSlot>(true);
    }
    private void Start()
    {
        PlayerState.Instance.Inven.ShowItemLog += ShowItemLog;
    }
    private void ShowItemLog(Item item)
    {
        for(int i = 0;i< itemLog.Length;i++)
        {
            if(!itemLog[i].gameObject.activeSelf)
            {
                itemLog[i].gameObject.SetActive(true);
                itemLog[i].SetUp(item);
                return;
            }
        }
        itemLog[0].gameObject.SetActive(false);
        itemLog[0].gameObject.SetActive(true);
        itemLog[0].SetUp(item);

    }
}

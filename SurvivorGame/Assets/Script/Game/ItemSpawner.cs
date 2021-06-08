using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] ITEM_TYPE itemName;
    [SerializeField] Transform spawnPivot;
    private void Start()
    {
        ItemObject item = ItemManager.Instance.MakeItem(itemName);
        item.transform.position = spawnPivot.position;
    }
}

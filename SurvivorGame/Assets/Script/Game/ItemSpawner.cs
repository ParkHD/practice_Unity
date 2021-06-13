using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item targetItem;
    [SerializeField] Transform spawnPivot;
    private void Start()
    {
        ItemObject item = ItemManager.Instance.MakeItem(targetItem.Name);
        item.transform.position = spawnPivot.position;
    }
}

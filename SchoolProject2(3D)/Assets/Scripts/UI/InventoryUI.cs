using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] Text itemInfo;
    [SerializeField] Text itemName;
    [SerializeField] Image itemImage;
    [SerializeField] Transform slotParent;
    [SerializeField] InventorySlotUI dummyItem;
    [SerializeField] RectTransform backImage;
    InventorySlotUI[] allSlots;
    private void Start()
    {
        Clear();
    }
    private void OnEnable()
    {
        if (allSlots == null)
        {
            allSlots = slotParent.GetComponentsInChildren<InventorySlotUI>();
            PlayerStatus.Instance.inven.OnUpdateInven += OnUpdateInven;

            for (int i = 0; i < allSlots.Length; i++)
            {
                allSlots[i].OnShowInfo += OnShowInfo;
                allSlots[i].OnItemInfoClear += OnItemInfoClear;
                allSlots[i].OnDragBegin += OnDragBegin;
                allSlots[i].OnDragging += OnDragging;
                allSlots[i].OnDragEnd += OnDragEnd;
            }
        }

        Cursor.lockState = CursorLockMode.None;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Clear()
    {
        OnItemInfoClear();
        for (int i = 0; i < allSlots.Length; i++)
        {
            allSlots[i].Clear();
        }
    }
    private void OnUpdateInven(Item[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            allSlots[i].SetUp(list[i]);
        }
    }

    private void OnShowInfo(Item item)
    {
        OnItemInfoClear();
        if (item == null)
            return;

        itemName.text = item.name.ToString();
        itemInfo.text = item.itemExplain;
        itemImage.enabled = true;
        itemImage.sprite = item.itemImage;
    }
    private void OnItemInfoClear()
    {
        itemName.text = string.Empty;
        itemInfo.text = string.Empty;
        itemImage.enabled = false;
    }
    private void OnDragBegin(Item item)
    {
        dummyItem.gameObject.SetActive(true);

        dummyItem.SetUp(item);
    }
    private void OnDragging()
    {
        dummyItem.transform.position = Input.mousePosition;
    }
    private void OnDragEnd(InventorySlotUI slot)
    {
        dummyItem.gameObject.SetActive(false);
        if (RectTransformUtility.RectangleContainsScreenPoint(backImage, Input.mousePosition))
        {
            PlayerStatus.Instance.inven.MoveItem(slot.transform.GetSiblingIndex(), InventorySlotUI.TargetSlotIndex);
        }
        else
        {
            PlayerStatus.Instance.inven.DropItem(slot.transform.GetSiblingIndex(), PlayerStatus.Instance.transform);;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventorySlot : MonoBehaviour
{
    Item item;

    [SerializeField] Image selectedImage;
    [SerializeField] Image itemImage;
    [SerializeField] Text itemCount;

    public event Action<Item> ShowInfo;
    public event Action ClearInfo;
    public event Action<Item> DragBegin;
    public event Action Dragging;
    public event Action DragEnd;

    public static int targetIndex;
    public static int originIndex;

    private void OnEnable()
    {
        if (selectedImage == null)
            return;
        selectedImage.enabled = false;
    }
    public void OnCursorEnter()
    {
        targetIndex = transform.GetSiblingIndex();
        selectedImage.enabled = true;
        ShowInfo(item);
    }
    public void OnCursorExit()
    {
        selectedImage.enabled = false;
        ClearInfo();
    }
    public void OnDragBegin()
    {
        originIndex = transform.GetSiblingIndex();
        DragBegin(item);
    }
    public void OnDragging()
    {
        Dragging();
    }
    public void OnDragEnd()
    {
        DragEnd();
        PlayerState.Instance.Inven.MoveItem(targetIndex, originIndex);
    }

    public void SetUp(Item item)
    {
        this.item = item;
        if (item == null)
        {
            Clear();
            return;
        }
        itemImage.enabled = true;

        itemImage.sprite = item.ItemImage;
        itemCount.text = item.Count > 1 ? item.Count.ToString() : "";
    }
    public void Clear()
    {
        itemImage.enabled = false;
        itemCount.text = "";
    }
}

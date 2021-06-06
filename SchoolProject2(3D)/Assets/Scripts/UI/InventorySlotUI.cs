using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] Image outline;
    [SerializeField] Text Count;
    [SerializeField] Image itemImage;
    [SerializeField] Image back;

    Item item;
    static int targetSlotIndex;
    public static int TargetSlotIndex => targetSlotIndex;

    private void Awake()
    {
        
    }
    private void Start()
    {
    }
    public event System.Action<Item> OnShowInfo;
    public event System.Action OnItemInfoClear;
    public event System.Action<Item> OnDragBegin;
    public event System.Action OnDragging;
    public event System.Action<InventorySlotUI> OnDragEnd;


    public void OnCursorEnter()
    {
        targetSlotIndex = transform.GetSiblingIndex();

        outline.enabled = true;
        OnShowInfo?.Invoke(item);
    }
    public void OnCursorExit()
    {
        outline.enabled = false;
        OnItemInfoClear?.Invoke();
    }
    public void OnCursorDragBegin()
    {
        OnDragBegin?.Invoke(item);
    }
    public void OnCursorDragging()
    {
        OnDragging?.Invoke();
    }
    public void OnCursorDragEnd()
    {
        OnDragEnd?.Invoke(this);
        
    }
    public void SetUp(Item item)
    {
        if (item == null)
            Clear();
        else
        {
            this.item = item;
            itemImage.enabled = true;
            itemImage.sprite = item.itemImage;
            Count.text = this.item.count > 0 ? item.count.ToString() : string.Empty;
            outline.enabled = false;
        }
    }
    public void Clear()
    {
        item = null;
        itemImage.enabled = false;
        Count.text = string.Empty;
        outline.enabled = false;
    }
}

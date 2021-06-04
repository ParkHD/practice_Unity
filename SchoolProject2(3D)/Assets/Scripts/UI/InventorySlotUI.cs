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

    private void Awake()
    {
        
    }
    private void Start()
    {
        Clear();
    }
    public event System.Action<Item> OnShowInfo;
    public event System.Action OnItemInfoClear;

    public void OnCursorEnter()
    {
        outline.enabled = true;
        OnShowInfo?.Invoke(item);
    }
    public void OnCursorExit()
    {
        outline.enabled = false;
        OnItemInfoClear?.Invoke();
    }
    public void SetUp(Item item)
    {
        this.item = item;
        back.raycastTarget = true;
        itemImage.enabled = true;
        itemImage.sprite = item.itemImage;
        Count.text = this.item.count > 0 ?item.count.ToString() : string.Empty;
        outline.enabled = false;
    }
    public void Clear()
    {
        back.raycastTarget = false;
        itemImage.enabled = false;
        Count.text = string.Empty;
        outline.enabled = false;
    }
}

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
    static int curSlotIndex;
    public static int CurSlotIndex => curSlotIndex;

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
    public event System.Action OnDragEnd;


    public void OnCursorEnter()
    {
        curSlotIndex = transform.GetSiblingIndex();
        Debug.Log(curSlotIndex);

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
        Debug.Log("ÇöÀç" + transform.GetSiblingIndex());
        PlayerStatus.Instance.inven.SwapItem(transform.GetSiblingIndex(), CurSlotIndex);
        OnDragEnd?.Invoke();
        
    }
    public void SetUp(Item item)
    {
        this.item = item;
        Debug.Log("Dd");
        itemImage.enabled = true;
        itemImage.sprite = item.itemImage;
        Count.text = this.item.count > 0 ?item.count.ToString() : string.Empty;
        outline.enabled = false;
    }
    public void Clear()
    {
        itemImage.enabled = false;
        Count.text = string.Empty;
        outline.enabled = false;
    }
}

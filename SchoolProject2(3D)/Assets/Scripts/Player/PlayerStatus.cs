using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    public event System.Action<Item[]> OnUpdateInven;

    Item[] inven = new Item[15];

    public void GetItem(Item item)
    {
        for(int i = 0;i<inven.Length;i++)
        {
            if(inven[i] == null)
            {
                inven[i] = item;
                break;
            }
        }
        OnUpdateInven(inven);
    }
    public void ShowInven()
    {
        
    }
    public void MoveItem(int originIndex, int targetIndex)
    {
        Item temp = inven[originIndex];
        inven[originIndex] = inven[targetIndex];
        inven[targetIndex] = temp;
        OnUpdateInven(inven);
    }
    public void DropItem(int index, Transform pos)
    {
        ItemObject dropitem = ItemManager.Instance.MakeItem(inven[index].name);
        dropitem.transform.position = pos.position;
        dropitem.GetComponent<Rigidbody>().AddForce(pos.forward * 6f, ForceMode.Impulse);

        inven[index] = null;
        Debug.Log(inven[index]);
        OnUpdateInven(inven);
    }
}

public class PlayerStatus : MonoBehaviour
{
    private static PlayerStatus instance;
    public static PlayerStatus Instance => instance;

    Dictionary<KeyCode, Action> InputEvent;

    [SerializeField] GameObject invenUI;

    public Inventory inven;
    bool OnInven;

    bool isStopMove;
    bool isStopRotate;
    bool isStopControl;
    public bool IsStopMove => isStopMove;
    public bool IsStopRotate => isStopRotate;
    public bool IsStopControl => isStopControl;
    private void Awake()
    {
        instance = this;
        inven = new Inventory();
        InputEvent = new Dictionary<KeyCode, Action>();
    }
    private void Start()
    {
        OnRegestedEvent(KeyCode.I, ShowInven);
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            for (KeyCode type = 0; type < KeyCode.Mouse6; type++)
            {
                if (Input.GetKeyDown(type))
                {
                    //InventoryUi.Instance.SwitchInventory();
                    if (InputEvent.ContainsKey(type))
                    {
                        InputEvent[type]?.Invoke();
                    }
                    break;
                }
            }
        }
    }
    public void OnRegestedEvent(KeyCode key, Action OnCallBack)
    {
        if (!InputEvent.ContainsKey(key))
            InputEvent.Add(key, null);
        InputEvent[key] += OnCallBack;
    }
    public void ShowInven()
    {
        if(OnInven)
        {
            isStopRotate = true;
            invenUI.SetActive(true);
            OnInven = false;
        }
        else
        {
            isStopRotate = false;

            invenUI.SetActive(false);
            OnInven = true;
        }
    }
    public void DropItem(int index)
    {

    }
    public void UpdateState()
    {
        this.isStopMove = false;
        this.isStopRotate = false;
        this.isStopControl = false;
    }
    public void UpdateState(bool isStopMove, bool isStopRotate, bool isStopControl)
    {
        this.isStopMove = isStopMove;
        this.isStopRotate = isStopRotate;
        this.isStopControl = isStopControl;
    }
}

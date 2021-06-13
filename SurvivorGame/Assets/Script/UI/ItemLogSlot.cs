using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLogSlot : MonoBehaviour
{
    [SerializeField] Image itemIcon;
    [SerializeField] Text itemName;
    [SerializeField] Text itemCount;

    Animation ani;
    bool isClose = false;
    private void Awake()
    {
        ani = GetComponent<Animation>();
    }
    private void Update()
    {
        if(isClose)
        {
            if(!ani.isPlaying)
            {
                isClose = false;
                gameObject.SetActive(false);
            }
        }
    }
    public void SetUp(Item item)
    {
        itemIcon.sprite = item.ItemImage;
        itemName.text = item.Name;
        Debug.Log(item.Name);
        itemCount.text = item.Count.ToString();
        ani.Play("ItemLog_Show");

        transform.SetAsLastSibling();
        StartCoroutine(Close());
    }
    IEnumerator Close()
    {
        yield return new WaitForSeconds(3);
        ani.Play("ItemLog_Close");
        isClose = true;
    }
}

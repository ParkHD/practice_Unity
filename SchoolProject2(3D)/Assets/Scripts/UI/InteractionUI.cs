using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] Text text;
    bool isOn;
    GameObject[] child;

    private void Start()
    {
        child = new GameObject[transform.childCount];
        for(int i = 0;i< child.Length; i++)
        {
            child[i] = transform.GetChild(i).gameObject;
        }
    }
    private void Switch(bool isOn)
    {
        for (int i = 0; i < child.Length; i++) 
        {
            child[i].SetActive(isOn);
        }
    }
    private void Update()
    {
        if(string.IsNullOrEmpty(PlayerInteraction.TargetName))
        {
            Switch(false);
        }
        else
        {
            text.text = PlayerInteraction.TargetName;
            Switch(true);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] Text targetName;
    GameObject[] child;
    private void Start()
    {
        child = new GameObject[transform.childCount];
        for(int i = 0;i<transform.childCount;i++)
        {
            child[i] = transform.GetChild(i).gameObject;
        }
    }
    private void Update()
    {
        if(PlayerInteract.TargetName == null)
        {
            for(int i = 0;i<child.Length; i++)
            {
                child[i].SetActive(false);
            }
        }
        else
        {
            targetName.text = PlayerInteract.TargetName;
            for (int i = 0; i < child.Length; i++)
            {
                child[i].SetActive(true);
            }
        }
    }

}

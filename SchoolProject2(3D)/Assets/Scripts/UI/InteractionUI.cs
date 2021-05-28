using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] Text interactionText;
    GameObject[] childs;

    private void Start()
    {
        childs = new GameObject[transform.childCount];
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;
        }
    }

    private void SwitchChild(bool isOn)
    {
        for (int i = 0; i < childs.Length; i++)
            childs[i].SetActive(isOn);
    }

    private void Update()
    {
        if (string.IsNullOrEmpty(InteractionController.TargetName))
        {
            SwitchChild(false);
        }
        else
        {
            SwitchChild(true);
            interactionText.text = InteractionController.TargetName;
        }
    }

}

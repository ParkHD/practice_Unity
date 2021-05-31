using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iinteraction
{
    string GetName();
    void OnInteract();
}

public class Npc : MonoBehaviour, Iinteraction
{
    [SerializeField] float turnSpeed;
    public new string name;

    bool isInteract; // 처음상태는 UI 꺼져있어서 
    bool isLooking;
    private void Update()
    {
        if(isInteract)
        {
            if (!isLooking)
            {
                Look();
            }
            if (!UImanager.Instance.NpcChat.activeSelf)
            {
                transform.localRotation = Quaternion.Euler(Vector3.zero);
                isInteract = false;
                isLooking = false;
            }
        }
    }
    public string GetName()
    {
        return name;
    }
    public void OnInteract()
    {
        isInteract = true;
        Debug.Log("오늘 장사 안해유");
        UImanager.Instance.OnChat(true);
        PlayerInteraction.controller.enabled = false;
    }
    private void Look()
    {
        float dir = GameManager.Instance.PlayerPos().x > transform.position.x ? -1 : 1;
        Vector3 pos = new Vector3(GameManager.Instance.PlayerPos().x - transform.position.x, 0f, GameManager.Instance.PlayerPos().z - transform.position.z);
        if (Mathf.Abs(transform.rotation.y) < Mathf.Abs(Quaternion.FromToRotation(Vector3.forward, pos).y))
        {
            isLooking = true;
        }
        transform.Rotate(dir * Vector3.up * turnSpeed* Time.deltaTime);
    }
}


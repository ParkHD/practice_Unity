using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iinteraction
{
    string GetName();
    void OnInteract();
}
public class Item : MonoBehaviour
{
    public new string name; 
    public string GetName()
    {
        return name;
    }
}
public class Npc : MonoBehaviour, Iinteraction
{
    [SerializeField] new Camera camera;
    [SerializeField] Vector3 camPosition;
    [SerializeField] float camRotateY;
    public new string name;

    private void Update()
    {
        
    }
    public string GetName()
    {
        return name;
    }
    public void OnInteract()
    {
        Debug.Log("오늘 장사 안해유");
        UImanager.Instance.OnChat(true);
        PlayerInteraction.controller.enabled = false;
        //Look();
    }
    private void Look()
    {
        camera.transform.rotation = transform.rotation;
        camera.transform.Rotate(new Vector3(20f, camRotateY, 0f));
        camera.transform.position = transform.position + camPosition;
    }
}


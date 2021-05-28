using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int count;
}

public abstract class Interaction : MonoBehaviour
{
    public abstract string GetName();
    public abstract Item GetItem();
}

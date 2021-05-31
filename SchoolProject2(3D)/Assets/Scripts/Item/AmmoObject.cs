using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ammo : Item 
{
    public Ammo(Ammo copy)
        : base(copy)
    {

    }
}

public class AmmoObject : ItemObject
{

}

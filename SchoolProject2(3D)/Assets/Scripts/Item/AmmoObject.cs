using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class Ammo : Item
{
    // Åº¾à Á¤º¸...
}

public class AmmoObject : Interaction
{
    [SerializeField] Ammo ammo;
    public override string GetName()
    {
        return ammo.name;
    }
    public override Item GetItem()
    {
        Destroy(gameObject);
        return ammo;
    }
}

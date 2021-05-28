using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class Ammo : Item
{
    // ź�� ����...
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

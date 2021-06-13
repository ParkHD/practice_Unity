using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo", menuName = "NewItem/Ammo")]
public class Ammo : Item
{
    public enum AmmoType
    {
        _5_56mm,
        _7_62mm,
    }

    [SerializeField] AmmoType type;

    public Ammo(Ammo ammo)
        : base(ammo)
    {
        type = ammo.type;
        itemType = type.ToString();
    }
}

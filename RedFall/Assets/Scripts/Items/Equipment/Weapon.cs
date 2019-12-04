using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    public WeaponType WeaponType { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, WeaponType type, int damage)
    {
        this.Name = name;
        this.WeaponType = type;
        this.Damage = damage;
    }
}

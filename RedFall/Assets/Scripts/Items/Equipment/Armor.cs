using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    public ArmorType ArmorType { get; set; }
    public int Protection { get; set; }

    public Armor(string name, ArmorType type, int protection)
    {
        this.Name = name;
        this.ArmorType = type;
        this.Protection = protection;
    }
}

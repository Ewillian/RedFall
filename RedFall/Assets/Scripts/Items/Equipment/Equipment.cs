using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : Item
{    
    public EquipmentType EquipmentType { get; set; }

    // modifiers
    public int Health_points { get; set; }
    public int Energy_points { get; set; }
    public int Mana_points { get; set; }
    public int Vitality { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Dexterity { get; set; }
    public int Strenght { get; set; }
}

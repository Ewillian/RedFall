using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public string Name { get; set; }
    public int Health_points { get; set; }
    public int Energy_points { get; set; } // physic
    public int Mana_points { get; set; } // magic
    public int Vitality { get; set; } // increase max hp
    public int Constitution { get; set; } // increase max energy
    public int Intelligence { get; set; } // increase max mana
    public int Wisdom { get; set; } // increase mana regeneration
    public int Dexterity { get; set; } // increase precision with weapons, evasion and initiative speed
    public int Strenght { get; set; } // increase damages with melee weapons
}

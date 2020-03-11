using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    private const int INVENTORY_MAX_SIZE = 20;

    public string Name { get; set; }
    public Class Class { get; set; }
    private List<Item> inventory { get; set; } = new List<Item>();
    // public List<Equipment> equipments {get; set; }

    public int Health_points { get; set; }
    public int Energy_points { get; set; } // physic
    public int Mana_points { get; set; } // magic
    public int Vitality { get; set; } // increase max hp
    public int Constitution { get; set; } // increase max energy
    public int Intelligence { get; set; } // increase max mana
    public int Wisdom { get; set; } // increase mana regeneration
    public int Dexterity { get; set; } // increase precision with weapons, evasion and initiative speed
    public int Strenght { get; set; } // increase damages with melee weapons

    public bool isActionSuccess(Character target)
    {
        bool value = true;
        // Est-ce que je touche la cible ? esquive, evasion, miss, ...
        return value;
    }

    public int dealDamages(Character target)
    {
        int value = 5;
        // Calcule des dommages selon force, puissance, resistances, armure, ...
        return value;
    }

    public bool addItemToInventory(Item item)
    {
        if (this.inventory.Count < INVENTORY_MAX_SIZE)
        {
            this.inventory.Add(item);
            return true;
        }
        return false;
    }

    public bool removeItemFromInventory(int index)
    {
        if (this.inventory.Count >= index - 1)
        {
            this.inventory.RemoveAt(index);
            return true;
        }
        return false;
    }

    public bool removeItemFromInventory(Item itemToRemove)
    {
        return this.inventory.Remove(itemToRemove);
    }

    public List<Item> getInventory()
    {
        return this.inventory;
    }

    public override string ToString()
    {
        return this.Class + " " + this.Name + " (PV = " + this.Health_points + ")";
    }
}

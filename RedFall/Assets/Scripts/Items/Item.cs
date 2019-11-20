using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ItemRarity Rarity { get; set; }
    public ItemType ItemType { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    public Dictionary<Item, bool> Inventory { get; private set; }

    public InventoryComponent()
    {
        Inventory = new Dictionary<Item, bool>();
    }

    public void AddToInventory(Item item)
    {
        Inventory.Add(item, false);
    }

    public void AddToInventory(Equippable equippable)
    {
        Inventory.Add(equippable, true);
    }

}

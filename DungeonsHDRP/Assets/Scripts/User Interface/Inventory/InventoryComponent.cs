using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InventoryComponent : MonoBehaviour
{
    [SerializeField]
    public List<Item> Inventory = new List<Item>();
    public UnityEvent PickupItemEvent = new UnityEvent();
    public bool DestroyIfEmpty = false;
    


    public void AddToInventory(Item item)
    {
        Inventory.Add(item);
    }

    public void AddToInventory(Equippable equippable)
    {
        Inventory.Add(equippable);
    }

    public void OpenInInventory() 
    {
        InventoryInterface.GetInstance().LoadPlayerInventory(this);
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if(Inventory.Count == 0 && this.DestroyIfEmpty) 
        {
            Destroy(this.gameObject);
        }
    }


}

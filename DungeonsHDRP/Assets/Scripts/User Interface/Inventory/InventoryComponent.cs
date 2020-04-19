using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InventoryComponent : MonoBehaviour
{
    [SerializeField]
    public List<Item> Inventory;
    public UnityEvent PickupItemEvent;
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
        InventoryInterface.GetInstance().OpenInventory(this);
    }
    private void Start()
    {
        PickupItemEvent.Invoke();
    }
    private void Update()
    {
        if(Inventory.Count == 0 && this.DestroyIfEmpty) 
        {
            Destroy(this.gameObject);
        }
    }


}

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
    public Equippable equipped;
    public Equippable equipped2;
    public GameObject WeaponAttachmentPoint;
    public GameObject MiscAttachmentPoint2;



    public void AddToInventory(Item item)
    {
        Inventory.Add(item);
    }

    public void AddToInventory(Equippable equippable)
    {
        Inventory.Add(equippable);
    }

    public void Equip(Item item)
    {
       
        if (item.Equippable == true) 
        {

            if (((Equippable)item).Type == Equippable.EquippableType.Weapon)
            {
                if(equipped == null) 
                {
                    equipped = (Equippable)item;
                    equipped.gameObject.transform.parent = WeaponAttachmentPoint.transform;
                    equipped.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    equipped.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    equipped.gameObject.SetActive(true);
                    equipped.GetComponent<Interactible>().SetInteractable(false);
                }
                else 
                {
                    Console.GetInstance().StartTransitionIn("Weapon slot full!");
                }
                
            }
            else 
            {
                if (equipped2 == null)
                {
                equipped2 = (Equippable)item;
                equipped2.gameObject.transform.parent = MiscAttachmentPoint2.transform;
                equipped2.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                equipped2.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                equipped2.gameObject.SetActive(true);
                equipped2.GetComponent<Interactible>().SetInteractable(false);
                }
                else
                {
                    Console.GetInstance().StartTransitionIn("Hand slot full!");
                }
            }

        }
        else 
        {
            Console.GetInstance().StartTransitionIn("Item is not equippable.");
        }
    }
    public void Unequip(int slot)
    {
        if (slot == 1)
        {
            if (equipped != null)
            {
                equipped.gameObject.SetActive(false);
                equipped = null;
            }
        }
        if (slot == 2)
        {
            if (equipped2 != null)
            {
                equipped2.gameObject.SetActive(false);
                equipped2 = null;
            }
        }

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

#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion
//UNFINISHED CLASS
public class Inventory : UIElement
{
    #region Fields
    private static Inventory _InventoryInstance;

    public Sprite DefaultItemImage;

    public GameObject WeaponSlot0;
    public GameObject WeaponSlot1;
    public GameObject WeaponSlot2;

    public GameObject QuestItemSlot0;
    public GameObject QuestItemSlot1;
    public GameObject QuestItemSlot2;

    public Item Weapon0;
    public Item Weapon1;
    public Item Weapon2;

    public Item QuestItem0;
    public Item QuestItem1;
    public Item QuestItem2;

    public RawImage WeaponSlotImage0;
    public RawImage WeaponSlotImage1;
    public RawImage WeaponSlotImage2;

    public RawImage QuestSlotImage0;
    public RawImage QuestSlotImage1;
    public RawImage QuestSlotImage2;
    public static List<Item> AvailableItems;
    public static List<Weapon> AvailableWeapons;

    private List<GameObject> SlotList;
    private Item selectedItemForUse;
    #endregion

    //Singleton-guarantee method
    public static Inventory GetInstance()
    {
        if (_InventoryInstance == null)
        {
            _InventoryInstance = FindObjectOfType<Inventory>();
        }
        return _InventoryInstance;
    }
}

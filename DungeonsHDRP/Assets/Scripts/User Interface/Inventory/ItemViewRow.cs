using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewRow : MonoBehaviour
{
    public Image ItemImage;
    public Item Item;
    public Button UseButton;
    public Button EquipButton;
    private bool IsEquippable;

    public delegate void UseItemDelegate(Item item);
    public delegate void EquipItemDelegate(Equippable equippable);

    public UseItemDelegate OnUseItem;

    public void SetItem(Equippable equippable)
    {
        this.Item = equippable;
        this.IsEquippable = true;
        ReloadViewRow();
    }

    public void SetItem(Item item)
    {
        this.Item = item;
        this.IsEquippable = false;
        ReloadViewRow();
        
    }
     public void ReloadViewRow()
    {
        ItemImage.sprite = Item.ItemImage;
        this.EquipButton.interactable = IsEquippable;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

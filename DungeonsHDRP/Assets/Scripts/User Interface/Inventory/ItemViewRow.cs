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
    public Toggle Selector;
    public Text ItemName;
    private bool IsEquippable;

    public delegate void UseItemDelegate(Item item);
    public delegate void EquipItemDelegate(Equippable equippable);

    public UseItemDelegate OnUseItem;

    public void SetItem(Equippable equippable)
    {
        this.Item = equippable;
        this.ItemName.text = equippable.name;
        this.ItemImage.sprite = equippable.ItemImage;
        this.IsEquippable = true;
        ReloadViewRow();
    }

    public void ExamineItem() 
    {
        Console.GetInstance().StartTransitionIn(string.Format("{0}\r\n{1}",Item.Name,Item.Description));
    }

    public void SetItem(Item item)
    {
        this.Item = item;
        this.ItemName.text = item.name;
        this.ItemImage.sprite = item.ItemImage;
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

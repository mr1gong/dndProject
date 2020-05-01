using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterface : UIElement
{
    public GameObject InventoryListViewPort;
    public Button ButtonTransfer;
    public Button ButtonDrop;
    public Dropdown InventorySelector;
    private InventoryComponent _playerInventoryCache;
    private InventoryComponent _targetInventoryCache;
    public GameObject ItemRowPrefab;
    private static InventoryInterface _InventoryInstance;
    public Item Selection;

    public Image EquippedImage;
    public Image EquippedImage2;


    public void ResetInventoryList()
    {
        ItemViewRow[] itemRows = InventoryListViewPort.GetComponentsInChildren<ItemViewRow>();
        foreach (var v in itemRows)
        {
            Destroy(v.gameObject);
        }
    }
    public void Equip(Item item) 
    {
        Protagonist.GetPlayerInstance().Inventory.Equip(item);
        
        if(Protagonist.GetPlayerInstance().Inventory.equipped != null) 
        {
            EquippedImage.sprite = Protagonist.GetPlayerInstance().Inventory.equipped.ItemImage;
        }
        else { EquippedImage.sprite = null; }

        if (Protagonist.GetPlayerInstance().Inventory.equipped2 != null)
        {
            EquippedImage2.sprite = Protagonist.GetPlayerInstance().Inventory.equipped2.ItemImage;
        }
        else { EquippedImage2.sprite = null; }


    }

    public void Unequip(int slot) 
    {
        if(slot == 1) 
        {
            EquippedImage.sprite = null;
            Protagonist.GetPlayerInstance().Inventory.Unequip(1);
        }
        if(slot == 2) 
        {
            EquippedImage2.sprite = null;
            Protagonist.GetPlayerInstance().Inventory.Unequip(2);
        }
    }
       

    private void Update()
    {

        if(Selection != null) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.PositiveInfinity, LayerMask.GetMask("Clickable")))
                {
                    Debug.Log("HIT" + hit.collider.gameObject.tag+hit.collider.gameObject.name);
                    GameObject hitout = hit.collider.gameObject;
                    string response = "";
                    hitout.GetComponent<Interactible>().GetItemUsedOn(Selection, out response);
                    Console.GetInstance().StartTransitionIn(response);
                    Selection = null;
                }
            }
        }
    }

    public void TransferBetweenInventories()
    {
        if (_targetInventoryCache != null)
        {
            ItemViewRow[] itemRows = InventoryListViewPort.GetComponentsInChildren<ItemViewRow>();
            List<ItemViewRow> rowList = new List<ItemViewRow>(itemRows);

            List<Item> selectedItems = rowList.Where(x => x.Selector.isOn).Select(x => x.Item).ToList();

            if (this.InventorySelector.value == 0)
            {
                selectedItems.ForEach(x => { _targetInventoryCache.Inventory.Add(x); });
                selectedItems.ForEach(x => { _playerInventoryCache.Inventory.Remove(x); });
            }
            else 
            {
                selectedItems.ForEach(x => { _playerInventoryCache.Inventory.Add(x); });
                selectedItems.ForEach(x => { _targetInventoryCache.Inventory.Remove(x); });
            }
            ReloadInventory();
        }
        
    }

    private void Start()
    {
        this._playerInventoryCache = Protagonist.GetPlayerInstance().Inventory;
    }

    public void SwitchSelectedInventory(int inventoryNum = 0) 
    {
        if(inventoryNum == 0) 
        {
            //Player
            LoadInventoryToDisplay(_playerInventoryCache);
        }
        else 
        {
            LoadInventoryToDisplay(_targetInventoryCache);
        }
    }

    public void OpenInventory(InventoryComponent inventory)
    {
        this._targetInventoryCache = inventory;
        LoadInventoryToDisplay(inventory);
        SwitchState(true);
        this.InventorySelector.value = 1;
        this.InventorySelector.interactable = true;
    }

    public void SwitchDisplayInventory() 
    {
       
    }
    public void OpenInventory()
    {
        LoadInventoryToDisplay(this._playerInventoryCache);
        this.InventorySelector.value = 0;
        this.InventorySelector.interactable = false;
    }
    public void LoadInventoryToDisplay(InventoryComponent inventory)
    {
        ResetInventoryList();
        if (inventory != null)
        {
            foreach (var v in inventory.Inventory)
            {
                GameObject row = Instantiate(ItemRowPrefab, InventoryListViewPort.transform);
                ItemViewRow rowcomp = row.GetComponentInChildren<ItemViewRow>();
                rowcomp.SetItem(v);
                rowcomp.EquipButton.interactable = true;

            }
        }
        else 
        {
            ResetInventoryList();
        }
        
    }

    public void ReloadInventory() 
    {
        ResetInventoryList();
        Debug.Log(InventorySelector.value);
        Debug.Log(_targetInventoryCache);
        switch (InventorySelector.value)
        {
            case 1: LoadInventoryToDisplay(this._targetInventoryCache); break;
            default: LoadInventoryToDisplay(this._playerInventoryCache); break;
        }
    }

    public override void SwitchState()
    {
        base.SwitchState();
        if (!this.isActive)
        {
            this._targetInventoryCache = null;
        }
    }

    public override void SwitchState(bool state)
    {
        base.SwitchState(state);
        if(state == false) 
        {
            this._targetInventoryCache = null;
        }
    }

    public static InventoryInterface GetInstance()
    {
        if (_InventoryInstance == null)
        {
            _InventoryInstance = FindObjectOfType<InventoryInterface>();
        }
        return _InventoryInstance;
    }
}

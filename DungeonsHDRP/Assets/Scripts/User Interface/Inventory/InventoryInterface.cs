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
    public Button ButtonExamine;
    public Dropdown InventorySelector;
    private InventoryComponent _playerInventoryCache;
    private InventoryComponent _targetInventoryCache;
    public GameObject ItemRowPrefab;
    private static InventoryInterface _InventoryInstance;

    public void ResetInventoryList()
    {
        ItemViewRow[] itemRows = InventoryListViewPort.GetComponentsInChildren<ItemViewRow>();
        foreach (var v in itemRows)
        {
            Destroy(v.gameObject);
        }
    }

    private void Update()
    {
        if(_targetInventoryCache == null) 
        {
            this.ButtonTransfer.interactable = false;
            this.InventorySelector.interactable = false;
        }
        else 
        {
            this.ButtonTransfer.interactable = true;
            this.InventorySelector.interactable = true;
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

    public void SwitchSelectedInventory(int inventoryNum = 0) 
    {
        if(inventoryNum == 0) 
        {
            //Player
            LoadPlayerInventory(_playerInventoryCache);
        }
        else 
        {
            LoadPlayerInventory(_targetInventoryCache);
        }
    }


    public void LoadPlayerInventory(InventoryComponent inventory)
    {
        _playerInventoryCache = inventory;
        if (inventory != null)
        {
            foreach (var v in inventory.Inventory)
            {
                GameObject row = Instantiate(ItemRowPrefab);
                ItemViewRow rowcomp = row.GetComponent<ItemViewRow>();
                rowcomp.Item = v;
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
        if(this.InventorySelector.value == 0) 
        {
            LoadPlayerInventory(this._playerInventoryCache);
        }
        else 
        {
            if(this.InventorySelector.value == 1) 
            {
            
                if(this._targetInventoryCache == null) 
                {
                    this.ResetInventoryList();
                }
                else 
                {
                    this.LoadPlayerInventory(_targetInventoryCache);
                }
            }
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
        if(!state) 
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

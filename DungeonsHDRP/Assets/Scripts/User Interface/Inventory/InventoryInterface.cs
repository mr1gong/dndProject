using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour
{
    public GameObject InventoryListViewPort;
    public Button ButtonTransfer;
    public Button ButtonDrop;
    public Button ButtonExamine;
    public Dropdown InventorySelector;

    public GameObject ItemRowPrefab;

    public void ResetInventoryList()
    {
        ItemViewRow[] itemRows = InventoryListViewPort.GetComponentsInChildren<ItemViewRow>();
        foreach(var v in itemRows)
        {
            Destroy(v.gameObject);
        }
    }

    public void LoadPlayerInventory(InventoryComponent inventory)
    {
        for
    }
}

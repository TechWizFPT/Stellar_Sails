using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public event EventHandler OnItemListChanged;

    public List<ItemSlot> itemList;
    [SerializeField] Inventory_UI InventoryUI;
    public Inventory()
    {
           itemList = new List<ItemSlot>();
    }
    public void AddItem(ItemSlot item)
    {
        foreach(ItemSlot inventoryItem in itemList)
        {
            if(inventoryItem.itemID == item.itemID)
            {
                inventoryItem.value += item.value;
            }
            else
            {
                itemList.Add(item);
            }
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Init()
    {
        InventoryUI.SetInventory(this);
    }
    public List<ItemSlot> GetItemList()
    {
        return itemList;
    }

    private void Awake()
    {
        Init();
    }
}

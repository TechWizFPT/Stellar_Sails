using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] GameObject baseItemSlotPrefab;
    [SerializeField] GameObject panel;
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    private void Inventory_OnItemListChanged (object sender , System.EventArgs e)
    {
        RefreshInventoryItems();
    }
    private void RefreshInventoryItems()
    {
        foreach(ItemSlot item in inventory.GetItemList())
        {
            //GameObject itemSlot = Instantiate(baseItemSlotPrefab);
            //itemSlot.transform.parent = panel.transform;
            //ItemSlot ItemSlot = itemSlot.AddComponent<ItemSlot>();
            //ItemSlot.Init(item);

        }
    }
}

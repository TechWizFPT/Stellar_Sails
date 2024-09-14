using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public ItemData itemData;
    public string itemID;
    public string itemName;
    public int value;
    
    public void Init(ItemData itemData)
    {
        itemID = itemData.itemID;
        itemName = itemData.itemName;
        
    }
}

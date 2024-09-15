using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = "New ItemData",menuName ="ScriptableObject/Item",order = 2)]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string itemID;
    public Sprite itemIcon;

    public string itemInfo;
    public ItemType itemType;
}

public enum ItemType
{
    CraftedItem, Artifact, SpaceDebris, CrystalShard
}

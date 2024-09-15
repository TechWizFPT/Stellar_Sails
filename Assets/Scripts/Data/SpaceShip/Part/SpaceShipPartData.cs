using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct ShipPart
{
    public int damage;
    public float attackTime;
    public int amount;

    public int slot;

    public float moveSpeed;
}

[CreateAssetMenu(fileName = "New part", menuName = "ScriptableObject/SpaceShipPart", order = 0)]

public class SpaceShipPartData : ScriptableObject
{
    public enum PartType
    {
        Gun,
        Cago,
        Engine,
    }

    public PartType partType;
    public string partName;


    public List<ShipPart> partInfo;   


}

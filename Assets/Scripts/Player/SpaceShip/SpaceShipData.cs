using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpaceShip",menuName ="ScriptableObject/SpaceShip",order = 1)]
public class SpaceShipData : ScriptableObject
{
    public int spaceShipID = 0;
    public string spaceShipName = "New SpaceShip";

    public int spaceShipHp = 100;
    public float moveSpeed = 10;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Planet", menuName = "ScriptableObject/Planet", order = 0)]

public class PlanetData : ScriptableObject
{
    public GameObject prefab;

    public string planetName;
    public List<ItemData> itemList;
}

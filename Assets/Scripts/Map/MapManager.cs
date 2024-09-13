using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] int mapW;
    [SerializeField] int mapH;
    [SerializeField] MapControlller mapControlllerPrefab;
    [SerializeField] List<MapControlller> mapControlllers = new List<MapControlller>();
    // Start is called before the first frame update
    void Start()
    {
        BuildMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildMap()
    {
        for(int i = 0; i < mapW; i++)
        {
            for (int j = 0; j < mapH; j++)
            {
                Vector3 mapPotion = new Vector3( mapControlllerPrefab.mapW*2 * i,0,mapControlllerPrefab.mapH*2 * j);
                Instantiate(mapControlllerPrefab, mapPotion, Quaternion.identity);
            }
        }
    }
}

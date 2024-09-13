using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControlller : MonoBehaviour
{
    public float mapW;
    public float mapH;

    [SerializeField] Transform mapAnchor;
    [SerializeField] GameObject mapObject;

    [SerializeField] Planet planetPrefab;
    [SerializeField] float borderPadding;
    [SerializeField] List<Planet> planetList;
    // Start is called before the first frame update
    void Start()
    {
        //BuildMapBoder();
        CreateRandomPlanet();
    }

    // Update is called once per frame
    void Update()
    {

    }

   
    void BuildMapBoder()
    {
        Vector3 borderTranform = new Vector3(mapAnchor.position.x + mapW, mapAnchor.position.y, mapAnchor.position.z);
        var tmp =  Instantiate(mapObject, borderTranform, Quaternion.identity);
        tmp.transform.SetParent(this.transform);

        borderTranform = new Vector3(mapAnchor.position.x - mapW, mapAnchor.position.y, mapAnchor.position.z);
        tmp= Instantiate(mapObject, borderTranform, Quaternion.identity);
        tmp.transform.SetParent(this.transform);


        borderTranform = new Vector3(mapAnchor.position.x , mapAnchor.position.y, mapAnchor.position.z + mapH);
        tmp= Instantiate(mapObject, borderTranform, Quaternion.identity);
        tmp.transform.SetParent(this.transform);

        borderTranform = new Vector3(mapAnchor.position.x, mapAnchor.position.y, mapAnchor.position.z - mapH);
        tmp = Instantiate(mapObject, borderTranform, Quaternion.identity);
        tmp.transform.SetParent(this.transform);

    }

    [ContextMenu("CreatePlane")]
    void CreateRandomPlanet()
    {
        ResetPlantList();

        int numbPlanet = Random.Range(1, 5);

        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(-mapW + borderPadding, mapW - borderPadding); 
            float z = Random.Range(-mapH + borderPadding, mapH - borderPadding); 
            var tmp =  Instantiate(planetPrefab,this.transform);
            tmp.transform.position = new Vector3 (transform.position.x + x,transform.position.y,
                transform.position.z + z);  

            planetList.Add(tmp);
        }
    }

    void ResetPlantList()
    {
        foreach(Planet planet in planetList)
        {
            Destroy(planet.gameObject);
        }

        planetList.Clear();
    }


}

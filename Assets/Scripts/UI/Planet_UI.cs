using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_UI : MonoBehaviour
{
    SpaceShipController spaceShipController;
    Planet planet;

    [SerializeField] GameObject resContainer;
    [SerializeField] PlanetInforBox_UI planetInforBoxPrefab;
    [SerializeField] List<PlanetInforBox_UI> planetInforBoxUIList;
    Action test;

    private void Awake()
    {
        UI_Observer.Instance.InteracWithPlanet += Active;
        test += TestActive;
    }

    private void OnEnable()
    {

    }

   
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("TTTTT");
            test?.Invoke();
        }
    }

    private void OnDisable()
    {
        planet = null;
        spaceShipController = null;
    }

    private void OnDestroy()
    {
        if (Application.isPlaying)
        {
            UI_Observer.Instance.InteracWithPlanet -= Active;
        }
        test = null;
    }

    void TestActive()
    {
        Debug.Log("Active UI");
        gameObject.SetActive(true);
    }

    void Active(SpaceShipController player, Planet _planet)
    {
        Debug.Log("Active UI");
        spaceShipController = player;
        planet = _planet;

        GetItemList(planet);
        
        gameObject.SetActive(true);
    }

    void GetItemList(Planet _planet)
    {
        if (planetInforBoxUIList != null) {
            if (planetInforBoxUIList.Count > 0) {
                for (int i = 0; i < planetInforBoxUIList.Count; i++) {                  
                    Destroy(planetInforBoxUIList[i]);
                }
                planetInforBoxUIList.Clear();
            }
        }

        for (int i = 0; i < _planet.planetData.itemList.Count; i++) { 
            var tmp = Instantiate(planetInforBoxPrefab,resContainer.transform);
            //tmp.itemData = _planet.planetData.itemList[i];
            tmp.Init(_planet.planetData.itemList[i]);
            planetInforBoxUIList.Add(tmp);
        }

    }

    //void Unactive(SpaceShipController player, Planet _planet)
    //{
    //    gameObject.SetActive(false);
    //}
}

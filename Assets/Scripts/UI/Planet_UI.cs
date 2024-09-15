using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_UI : MonoBehaviour
{
    [SerializeField] SpaceShipController spaceShipController;
    [SerializeField] Planet planet;
    Action test;

    private void Awake()
    {
        UI_Observer.Instance.InteracWithPlanet += Active;
        test += TestActive;
    }

    private void OnEnable()
    {
        //UI_Observer.Instance.InteracWithPlane += Active;

        //UI_Observer.Instance.InteracWithPlane += Active;

    }

    private void OnDisable()
    {

    }

    private void OnDestroy()
    {
        UI_Observer.Instance.InteracWithPlanet -= Active;
        test = null;

    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("TTTTT");
            test?.Invoke();
        }
    }

    void TestActive()
    {
        Debug.Log("Active UI");
        gameObject.SetActive(true);
    }

    void Active(SpaceShipController player,Planet _planet)
    {
        spaceShipController = player;
        planet = _planet;
        Debug.Log("Active UI");
        gameObject.SetActive(true);
    }

    //void Unactive(SpaceShipController player, Planet _planet)
    //{
    //    gameObject.SetActive(false);
    //}
}

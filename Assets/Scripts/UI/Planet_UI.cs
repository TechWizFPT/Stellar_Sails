using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_UI : MonoBehaviour
{
    [SerializeField] SpaceShipController spaceShipController;
    [SerializeField] Planet planet;

    private void Awake()
    {
        UI_Observer.Instance.InteracWithPlanet += Active;
    }

    private void OnEnable()
    {
        //UI_Observer.Instance.InteracWithPlanet += Active;
        UI_Observer.Instance.InteracWithPlanet -= Active;
        UI_Observer.Instance.InteracWithPlanet += Unactive;
    }

    private void OnDisable()
    {
        //UI_Observer.Instance.InteracWithPlanet -= Active;
        UI_Observer.Instance.InteracWithPlanet += Active;
        UI_Observer.Instance.InteracWithPlanet -= Unactive;

    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Active(SpaceShipController player,Planet _planet)
    {
        spaceShipController = player;
        planet = _planet;
        Debug.Log("Active UI");
        gameObject.SetActive(true);
    }

    void Unactive(SpaceShipController player, Planet _planet)
    {
        gameObject.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Observer : Singleton<UI_Observer>
{
    public Action<SpaceShipController, Planet> InteracWithPlanet;

    public Action<SpaceShipController> ShowUpgradeSpaceShipUI;
    public Action<SpaceShipPart> ShowPartInfo;

    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        InteracWithPlanet = null;
        ShowUpgradeSpaceShipUI = null;
        ShowPartInfo = null;

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (Application.isPlaying)
        {
            InteracWithPlanet = null;
            ShowUpgradeSpaceShipUI = null;
            ShowPartInfo = null;
        }
        
    }

   

    
}

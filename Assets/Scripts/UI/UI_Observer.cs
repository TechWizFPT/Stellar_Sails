using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Observer : Singleton<UI_Observer>
{

    public Action<SpaceShipController, Planet> InteracWithPlane;

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

    private void OnDestroy()
    {
        InteracWithPlane = null;
        ShowUpgradeSpaceShipUI = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

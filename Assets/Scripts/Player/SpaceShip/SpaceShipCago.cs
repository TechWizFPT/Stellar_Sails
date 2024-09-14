using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCago : SpaceShipPart
{
    // Start is called before the first frame update
    void Start()
    {
        partName = "CagoPart";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Active()
    {
        Debug.Log("Gun active");
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }
}

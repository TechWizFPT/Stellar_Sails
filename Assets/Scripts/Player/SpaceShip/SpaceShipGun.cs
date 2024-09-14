using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipGun : SpaceShipPart
{
    //public string gunName;
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        partName = "GunPart";
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

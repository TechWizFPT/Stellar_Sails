using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceShipPart : MonoBehaviour
{
    public SpaceShipPartData spaceShipPartData;
    public string partName;
    public int currentLv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void Upgrade()
    {
        if(spaceShipPartData.partInfo.Count -1 <= currentLv ) { return; }
        Debug.Log("Upgrade Part " + spaceShipPartData.partName);
        currentLv++;
    }

    public virtual void Active()
    {

    }
}

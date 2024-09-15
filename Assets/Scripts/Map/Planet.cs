using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour ,IInteracable
{
    public PlanetData planetData;
    public void Interact(SpaceShipController controller)
    {
        Debug.Log("Interact Plane");
        controller.InteractedWithPlaneCallBack(controller, this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

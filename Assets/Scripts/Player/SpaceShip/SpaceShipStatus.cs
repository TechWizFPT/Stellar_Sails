using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipStatus : MonoBehaviour
{
    [SerializeField] SpaceShipData spaceShipData;

    private float _currentMoveSpeed = 0;
    public float currentMoveSpeed {  get => _currentMoveSpeed; }

    // Start is called before the first frame update
    void Start()
    {
        _currentMoveSpeed = spaceShipData.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

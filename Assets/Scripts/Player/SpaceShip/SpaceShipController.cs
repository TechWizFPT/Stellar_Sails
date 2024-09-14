using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] SpaceShipStatus status;
    public Action<PlayerManager, Vector3> SpaceShipMove;
    public Action<PlayerManager> SpaceShipAttack;
    public Action<PlayerManager> SpaceShipInteract;

    private void Awake()
    {
        status = GetComponent<SpaceShipStatus>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        SpaceShipMove += Movement;
        SpaceShipAttack += Attack;
        SpaceShipInteract += Interact;
    }

    private void OnDisable()
    {
        SpaceShipMove -= Movement;
        SpaceShipAttack -= Attack;
        SpaceShipInteract -= Interact;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement(PlayerManager player, Vector3 moveDir)
    {
        transform.position += (moveDir * status.currentMoveSpeed * Time.deltaTime) ;
        //Debug.Log("Move");
    }

    void Interact(PlayerManager player)
    {
        Debug.Log("Interact Input");
        interacObject.Interact();
    }

    void Attack(PlayerManager player)
    {

    }

    public void TakeDamage()
    {

    }

    [SerializeField] IInteracable interacObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IInteracable>() != null)
        {
            interacObject = other.GetComponent<IInteracable>();
            //Debug.Log("Add Interact Obj");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IInteracable>() != null)
        {
            interacObject = null;
            //Debug.Log("Remove Interact Obj");

        }
    }
}

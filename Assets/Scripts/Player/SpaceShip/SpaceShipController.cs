using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] SpaceShipStatus status;
    public List<SpaceShipPart> spaceShipParts = new List<SpaceShipPart>();
    //[SerializeField] SpaceShipGun spaceShipGun;

    public Action<PlayerManager, Vector3> SpaceShipMove;
    public Action<PlayerManager> SpaceShipAttack;
    public Action<PlayerManager> SpaceShipInteract;


    private void Awake()
    {
        status = GetComponent<SpaceShipStatus>();
        //spaceShipGun = GetComponent<SpaceShipGun>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpaceShipPart[] part = GetComponentsInChildren<SpaceShipPart>();
        foreach(SpaceShipPart p in part)
        {
           spaceShipParts.Add(p);
        }


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
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Gun input");
            //UI_Observer.Instance.ShowPartInfo?.Invoke(spaceShipGun);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Show upgrade Panel");
            UI_Observer.Instance.ShowUpgradeSpaceShipUI?.Invoke(this);
        }
    }

    void Movement(PlayerManager player, Vector3 moveDir)
    {
        transform.position += (moveDir * status.currentMoveSpeed * Time.deltaTime);
        //Debug.Log("Move");
    }

    void Interact(PlayerManager player)
    {
        Debug.Log("Interact Input");
        if (interacObject != null)
        {
            interacObject.Interact(this);
        }
    }

    void Attack(PlayerManager player)
    {
        Debug.Log("SpaceShip Attack");
        foreach(SpaceShipPart part in spaceShipParts)
        {
            if (part is SpaceShipGun)
            {
                part.Active();
            }
        }
    }

    public void TakeDamage()
    {

    }

    public void InteractedWithPlaneCallBack(SpaceShipController controller ,Planet plane)
    {
        if (controller != this) { return; }
        UI_Observer.Instance.InteracWithPlanet?.Invoke(this,plane);

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

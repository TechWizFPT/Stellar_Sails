using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControllerInput : Singleton<SpaceShipControllerInput>
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] SpaceShipController spaceShipController;
    List<SpaceShipController> spaceShipControllers;
    bool isMove;
    [SerializeField] Vector3 moveDir;
    Action<SpaceShipController> moveInput;
    protected override void Awake()
    {
        base.Awake();

        spaceShipController = GetComponent<SpaceShipController>();
    }
    // Start is called before the first frame update
    protected override void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        InteractInput();
        AttackInput();

        
    }

    private void OnEnable()
    {

    }

    private void OnDestroy()
    {
    }

    void MoveInput()
    {
        if (spaceShipController == null) { return; }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            moveDir.x = Input.GetAxisRaw("Horizontal");
            moveDir.y = 0;
            moveDir.z = Input.GetAxisRaw("Vertical");

            spaceShipController.SpaceShipMove?.Invoke(playerManager, moveDir.normalized);

        }
        else
        {
            if (isMove)
            {
                isMove = false;
                moveDir = Vector3.zero;
                spaceShipController.SpaceShipMove?.Invoke(playerManager, moveDir.normalized);
            }
        }
    }

    void InteractInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            spaceShipController.SpaceShipInteract?.Invoke(playerManager);

        }
    }

    void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceShipController.SpaceShipAttack?.Invoke(playerManager);

        }
    }
 }

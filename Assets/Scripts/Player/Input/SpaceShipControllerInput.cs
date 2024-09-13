using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControllerInput : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] SpaceShipController spaceShipController;
    bool isMove;
    [SerializeField] Vector3 moveDir;
    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        spaceShipController = GetComponent<SpaceShipController>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        InteractInput();
    }

    void MoveInput()
    {
        if(spaceShipController == null) { return; }
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
                spaceShipController.SpaceShipMove?.Invoke(playerManager,moveDir.normalized);
            }
        }
    }

    void InteractInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceShipController.SpaceShipInteract?.Invoke(playerManager);

        }
    }
 }

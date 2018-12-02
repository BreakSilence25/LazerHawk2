using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    ShipBehaviour shipBehaviour;

    Vector3 moveInput;
    Vector3 rotateInput;

    bool powered = true;

	void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        shipBehaviour = GetComponent<ShipBehaviour>();
	}

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float u = Input.GetAxisRaw("Altitude");

        float rh = Input.GetAxisRaw("Mouse X");
        float rv = Input.GetAxisRaw("Mouse Y");
        float ru = Input.GetAxisRaw("Rotational");

        moveInput = new Vector3(h, u, v);
        rotateInput = new Vector3(rv, rh, ru);

        if(Input.GetKeyDown(KeyCode.P))
        {
            powered = !powered;
        }
    }

    void FixedUpdate ()
    {
        //send Input
        shipBehaviour.MoveInput(moveInput, rotateInput, powered);
	}
}

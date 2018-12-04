using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    ShipBehaviour shipBehaviour;

    Vector3 moveInput;
    Vector3 rotateInput;

    bool powered = true;

    bool inputEnabled = true;

    public float zoomFov = 30f;
    private float normalFov = 60f;

	void Start ()
    {

        shipBehaviour = GetComponent<ShipBehaviour>();
	}

    private void Update()
    {
        if (inputEnabled)
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

            if (Input.GetMouseButton(1))
            {
                Camera.main.fieldOfView = zoomFov;
            }
            else if (!Input.GetMouseButton(1))
            {
                Camera.main.fieldOfView = normalFov;
            }
        }
    }

    void FixedUpdate ()
    {
        //send Input
        shipBehaviour.MoveInput(moveInput, rotateInput, powered);
	}

    public void DisableInput(bool state)
    {
        if (inputEnabled)
        {
            inputEnabled = state;
        }
        else
        {
            return;
        }
    }
}

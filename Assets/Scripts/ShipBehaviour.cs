using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour, IKillable
{

    Vector3 positionInput;
    Vector3 rotationInput;

    bool isPowered = false;
    float shipSpeed = 150f;

    public int shipHealth;

    private WeaponBase weaponSystem;
    private Rigidbody shipRigidbody;

    void Start()
    {
        weaponSystem = GetComponent<WeaponBase>();
        shipRigidbody = GetComponent<Rigidbody>();

        shipHealth = 100;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Joystick1Button2))
        {
            weaponSystem.Shoot();
        }
    }

    public void MoveInput(Vector3 move, Vector3 rotate, bool power)
    {
        positionInput = move;
        rotationInput = rotate;
        isPowered = power;

        Move();
    }

    void Move()
    {
        if(isPowered)
        {
            shipSpeed = 150f;
            shipRigidbody.drag = 10;
        }
        else
        {
            shipSpeed = 0;
            shipRigidbody.drag = 0;
        }

        shipRigidbody.AddRelativeForce(positionInput * shipSpeed);
        shipRigidbody.AddRelativeTorque(rotationInput);
    }

    public virtual void TakeHit(int damage)
    {

    }

    public virtual void Die()
    {

    }

}

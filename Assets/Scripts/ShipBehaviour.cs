using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipBehaviour : MonoBehaviour, IKillable
{

    Vector3 positionInput;
    Vector3 rotationInput;

    bool isPowered = false;
    float shipSpeed = 150f;

    public int shipHealth;

    private WeaponBase weaponSystem;
    private Rigidbody shipRigidbody;

    public GameObject gameOverPanel;

    public bool isDead = false;

    void Start()
    {
        weaponSystem = GetComponent<WeaponBase>();
        shipRigidbody = GetComponent<Rigidbody>();

        shipHealth = 100;

        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.GetComponent<Image>().enabled = false;
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
        if (shipHealth <= 0 && !isDead)
        {
            isDead = true;
            Die();
        }
        else
        {
            shipHealth -= damage;
        }
    }

    [ContextMenu("Die")]
    public virtual void Die()
    {
        StartCoroutine(DeathGameOver());
    }

    IEnumerator DeathGameOver()
    {
        gameOverPanel.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1f);
        GameObject.Find("GameOverText").GetComponent<GUIGameOverText>().StartTyping();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

}

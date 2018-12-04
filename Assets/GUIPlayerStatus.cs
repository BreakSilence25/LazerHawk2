using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPlayerStatus : MonoBehaviour
{

    public ShipBehaviour ship;
    public Text statusText;

    private float currentPlayerHealth;

    void Start()
    {
        ship = GameObject.Find("Ship").GetComponent<ShipBehaviour>();
        statusText = GetComponent<Text>();
    }

    void FixedUpdate ()
    {
        currentPlayerHealth = ship.shipHealth;

        statusText.text = "Ship Status:" + currentPlayerHealth.ToString();

        if (currentPlayerHealth <= 0)
        {
            statusText.text = "Ship Status: ERROR";
        }
    }
}

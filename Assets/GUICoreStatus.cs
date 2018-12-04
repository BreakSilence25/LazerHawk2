using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUICoreStatus : MonoBehaviour
{

    public CoreBehaviour core;
    public Text statusText;

    private float currentCoreHealth;

	void Start ()
    {
        core = GameObject.Find("Core").GetComponent<CoreBehaviour>();
        statusText = GetComponent<Text>();
	}

    void FixedUpdate()
    {
        currentCoreHealth = core.coreHealth;

        statusText.text = "Core Status:" + currentCoreHealth.ToString();

        if (currentCoreHealth <= 0)
        {
            statusText.text = "Core Status: ERROR";
        }
    }

}

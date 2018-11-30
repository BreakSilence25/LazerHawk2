using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeDetector : MonoBehaviour
{

    public CoreBehaviour core;
    public WarningBehaviour warning;

	void Start ()
    {
        core = GetComponentInParent<CoreBehaviour>();
        warning = GameObject.Find("WarningSign").GetComponent<WarningBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            warning.Warning();
        }
    }
}

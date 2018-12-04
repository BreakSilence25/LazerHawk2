using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLookAt : MonoBehaviour
{

    private Transform lookTarget;
	
	void Start ()
    {
        lookTarget = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(lookTarget);
	}
}

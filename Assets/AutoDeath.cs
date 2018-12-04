using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeath : MonoBehaviour
{

    public float deathTime = 4f;

	void Start ()
    {
        StartCoroutine(StartDeath(deathTime));
	}
	
    IEnumerator StartDeath(float deathTime)
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}

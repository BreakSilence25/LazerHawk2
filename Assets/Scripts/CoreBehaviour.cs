using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBehaviour : MonoBehaviour, IKillable
{

    public int coreHealth;

	void Start ()
    {
        coreHealth = 100;
	}
	
	void Update ()
    {
        gameObject.transform.Rotate(Vector3.up, 0.5f);
	}

    public virtual void TakeHit(int damage)
    {

    }

    public virtual void Die()
    {

    }
}

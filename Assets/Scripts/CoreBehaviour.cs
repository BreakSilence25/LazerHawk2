using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBehaviour : MonoBehaviour, IKillable
{
    [SerializeField]
    private Collider rangeDetector;

    public int coreHealth;

	void Start ()
    {
        coreHealth = 100;

	}
	
	void Update ()
    {
        gameObject.transform.Rotate(Vector3.up, 0.4f);
    
    }


    public virtual void TakeHit(int damage)
    {

    }

    public virtual void Die()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : FadeEffect
{
    public LayerMask collisionMask;

    private Rigidbody projectileRigidbody;

    private float speed = 40;
    private int damage = 5;

	// Use this for initialization
	void Start ()
    {
        projectileRigidbody = GetComponent<Rigidbody>();

        StartCoroutine(Fade());
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float moveDistance = speed * Time.deltaTime;
        projectileRigidbody.AddRelativeForce(Vector3.forward * 200f);
        CheckCollisions(moveDistance);
	}

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
            Destroy(gameObject);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IKillable damageableObject = hit.collider.GetComponent<IKillable>();
        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage);
        }
    }
}

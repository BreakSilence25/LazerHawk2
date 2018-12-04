using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankBehaviour : MonoBehaviour, IKillable
{

    public LayerMask collisionMask;

    public int tankHealth;

    public WeaponBase tankGun;

    public Transform turretTransform;
    public Transform gunTransform;

    public Transform lookTarget;

    private NavMeshAgent navMeshAgent;

    bool isShooting = false;

    public GameObject deathFX;


    void Start ()
    {
        lookTarget = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
    {
        Ray ray = new Ray(transform.position, lookTarget.position - transform.position);
        RaycastHit hit;

        Debug.DrawRay(transform.position, lookTarget.position - transform.position, Color.red);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Player" && !hit.transform.GetComponent<ShipBehaviour>().isDead)
            {
                navMeshAgent.isStopped = false;
                LockOn();
                navMeshAgent.destination = new Vector3(lookTarget.position.x, 0, lookTarget.position.z);
            }
            else
            {
                navMeshAgent.isStopped = true;
            }
        }

    }

    void LockOn()
    {
        Vector3 lookDir = lookTarget.position - turretTransform.position;

        lookDir.y = 0; // keep only the horizontal direction
        turretTransform.rotation = Quaternion.LookRotation(lookDir);

        gunTransform.rotation = Quaternion.LookRotation(lookTarget.position - turretTransform.position);

        StartCoroutine(ShootSalvo());
    }

    void MovePatrol()
    {
        
    }

    IEnumerator ShootSalvo()
    {
        if (!isShooting)
        {
            isShooting = true;
            tankGun.Shoot();
            yield return new WaitForSeconds(0.5f);
            tankGun.Shoot();
            yield return new WaitForSeconds(0.5f);
            tankGun.Shoot();
            yield return new WaitForSeconds(4f);
            isShooting = false;
        }
    }

    public virtual void TakeHit(int damage)
    {
        if (tankHealth <= 0)
        {
            Die();
        }
        else
        {
            tankHealth -= damage;
        }
    }

    public virtual void Die()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

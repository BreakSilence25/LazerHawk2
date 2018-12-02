using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IKillable
{

    public LayerMask coreLayer;

    public int health;
    public float moveSpeed;
    public int coreDamage = 25;

    public float moveDistance;

    [SerializeField]
    private enemyType type;
    [SerializeField]
    private Transform core;

    bool isStunned = false;
    float stunTime;
	
	void Start ()
    {
        core = GameObject.Find("Core").transform;
        SetEnemyType();
	}
	
	void Update ()
    {
        moveDistance = (moveSpeed * Time.deltaTime) * 1000;

        CoreCollision();

        if (!isStunned)
        {
            gameObject.transform.LookAt(core);
            gameObject.transform.position = Vector3.MoveTowards(transform.position, core.position, Time.deltaTime * moveSpeed);
        }
	}

    void CoreCollision()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, coreLayer, QueryTriggerInteraction.Collide))
        {
            Debug.Log(type + " hit the core!");
            hit.collider.gameObject.GetComponent<CoreBehaviour>().TakeHit(coreDamage);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, Vector3.forward  * 10f);
    }

    void AttackPlayer()
    {
        // if player attack
        //if player close
    }

    public virtual void TakeHit(int damage)
    {
        if (health <= 0)
        {
            Die();
        }
        else
        {
            health -= damage;
            isStunned = true;
            StartCoroutine(StunTimer());
        }

    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public enum enemyType
    {
        drone,
        chaser,
        heavy
    }

    void SetEnemyType()
    {
        if (type == enemyType.drone)
        {
            health = 15;
        }
        else if (type == enemyType.chaser)
        {
            health = 25;
        }
        else if (type == enemyType.heavy)
        {
            health = 50;
        }
    }

    IEnumerator StunTimer()
    {
        yield return new WaitForSeconds(stunTime);
        isStunned = false;
    }
}

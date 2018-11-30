using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IKillable
{


    public int health;
    public float moveSpeed;

    [SerializeField]
    private enemyType type;
    [SerializeField]
    private Transform core;

    bool isStunned = false;
    float stunTime;
	
	void Start ()
    {
        core = GameObject.Find("Core").transform;
        SetEnemyLife();
	}
	
	void Update ()
    {
        if (!isStunned)
        {
            gameObject.transform.LookAt(core);
            gameObject.transform.position = Vector3.MoveTowards(transform.position, core.position, Time.deltaTime * moveSpeed);
        }
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

    void SetEnemyLife()
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

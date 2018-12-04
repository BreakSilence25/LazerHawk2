using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IKillable
{

    public float dirMultiplier = 1f;
    public float currentDistance;

    public LayerMask coreLayer;

    public int health;
    public float moveSpeed;
    public int coreDamage = 25;

    public float moveDistance;

    [SerializeField]
    private enemyType type;
    [SerializeField]
    private Transform core;
    [SerializeField]
    private GameObject deathFX;

    bool isStunned = false;
    bool isInvinceble = false;
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
        currentDistance = Vector3.Distance(transform.position, core.position);

        if (currentDistance < 10f)
        {
            Debug.Log("distance closed!");
            StartCoroutine(BreachTimer());
        }
    }

    void AttackPlayer()
    {
        // if player attack
        //if player close
    }

    public virtual void TakeHit(int damage)
    {
        if (!isInvinceble)
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
        else
        {
            //play invinceble sfx
            return;
        }

    }

    [ContextMenu("Die")]
    public virtual void Die()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
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

    IEnumerator BreachTimer()
    {
        isInvinceble = true;
        //play breach sfx
        yield return new WaitForSeconds(3);
        core.GetComponent<CoreBehaviour>().TakeHit(coreDamage);
        Die();
    }
}

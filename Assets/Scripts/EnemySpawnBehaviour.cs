using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBehaviour : MonoBehaviour
{

    public EnemyBase enemy;

	void Start ()
    {
        transform.LookAt(GameObject.Find("Core").transform);
	}
	
	void Update ()
    {
		
	}

    [ContextMenu("Spawn Enemy")]
    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}

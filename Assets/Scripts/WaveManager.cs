using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public enum spawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    }

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public Transform enemy;
        public int enemyCount;
        public float rate;
    }

    public Wave[] waves;
    public EnemySpawnBehaviour spawner;

    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    [SerializeField]
    private float searchCountdown = 1f;

    [SerializeField]
    private spawnState state = spawnState.COUNTING;

    public AudioClip startWaveSound;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        spawner = GameObject.Find("EnemySpawn").GetComponent<EnemySpawnBehaviour>();
        
    }

    private void Update()
    {
        if (state == spawnState.WAITING)
        {
            //check if enemies are alive
            if (!EnemyIsAlive())
            {
                //begin new wave
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != spawnState.SPAWNING)
            {
                //start spawning wave
                StartCoroutine(SpawnWave( waves [nextWave] ) );
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        if (!GameObject.Find("Core").GetComponent<CoreBehaviour>().isDead)
        {
            state = spawnState.COUNTING;
            waveCountdown = timeBetweenWaves;
        }
        else
        {
            return;
        }

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves Cleared! Looping back...");
        }

        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }         
            return true;

    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.waveName);
        state = spawnState.SPAWNING;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(startWaveSound);

        //spawn
        for (int i = 0; i < _wave.enemyCount; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = spawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy " + _enemy);
        for (int i = 0; i < spawner.spawnPoints.Length; i++)
        {
            Instantiate(_enemy, spawner.spawnPoints[i].transform);
        }
    }
}

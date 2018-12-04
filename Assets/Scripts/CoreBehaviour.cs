using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoreBehaviour : MonoBehaviour, IKillable
{

    private Collider rangeDetector;

    public GameObject gameOverPanel;
    public GUIGameOverText gameOverText;
    [SerializeField]
    private GameObject coreDeathFX;

    public int coreHealth;

    public bool isDead = false;

	void Start ()
    {
        coreHealth = 100;

        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.GetComponent<Image>().enabled = false;
        gameOverText = GameObject.Find("GameOverText").GetComponent<GUIGameOverText>();
	}
	
	void Update ()
    {
        gameObject.transform.Rotate(Vector3.up, 0.4f);
        if (coreHealth <= 0)
        {
            Die();
        }
    
    }


    public virtual void TakeHit(int damage)
    {
        if (coreHealth >= 0)
        {
            coreHealth -= damage;
        }
        else
        {
            Die();
        }
    }

    [ContextMenu("Die")]
    public virtual void Die()
    {
        if (!isDead)
        {
            isDead = true;
            EnemyBase[] allEnemies = FindObjectsOfType(typeof(EnemyBase)) as EnemyBase[];
            foreach (EnemyBase enemy in allEnemies)
            {
                enemy.Die();
            }
            StartCoroutine(StartGameOver());
        }
        else if (isDead)
        {
            return;
        }
    }

    IEnumerator StartGameOver()
    {

        GameObject.Find("Ship").GetComponent<PlayerInput>().DisableInput(false);
        Camera.main.transform.LookAt(transform.position);

        yield return new WaitForSeconds(3f);

        Instantiate(coreDeathFX, transform.position, transform.rotation);
        Camera.main.GetComponent<CameraShake>().isShaked = true;

        GameObject.Find("coreMesh").SetActive(false);

        yield return new WaitForSeconds(4f);
        gameOverPanel.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1f);
        gameOverText.StartTyping();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}

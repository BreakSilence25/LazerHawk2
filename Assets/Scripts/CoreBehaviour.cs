using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreBehaviour : MonoBehaviour, IKillable
{

    private Collider rangeDetector;

    public GameObject gameOverPanel;
    [SerializeField]
    private GameObject coreDeathFX;

    public int coreHealth;

    bool isDead = false;

	void Start ()
    {
        coreHealth = 100;

        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.GetComponent<Image>().enabled = false;

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
            GameObject.Find("coreMesh").SetActive(false);
            GameObject.Find("Ship").GetComponent<PlayerInput>().DisableInput(false);
            Camera.main.transform.LookAt(transform.position);
            Instantiate(coreDeathFX, transform.position, transform.rotation);
            StartCoroutine(StartGameOver());
        }
        else if (isDead)
        {
            return;
        }
    }

    IEnumerator StartGameOver()
    {
        yield return new WaitForSeconds(5f);
        gameOverPanel.GetComponent<Image>().enabled = true;
    }
}

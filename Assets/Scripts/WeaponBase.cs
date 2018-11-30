using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;
    [SerializeField]
    private List<Transform> projectileSpawns = new List<Transform>();

    private AudioSource gunSound;
    public AudioClip shotSound;


    public float msBetweenShots = 100f;

    float nextShotTime;
    bool isCooling;

	
	void Start ()
    {
        projectileSpawns.Add(GameObject.Find("ProjectileSpawn1").transform);
        projectileSpawns.Add(GameObject.Find("ProjectileSpawn2").transform);

        gunSound = GetComponent<AudioSource>();

	}
	
	
	void Update ()
    {
		
	}

    public void Shoot()
    {

        if (Time.time > nextShotTime && !isCooling)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;

            for (int i = 0; i < projectileSpawns.Count; i++)
            {
                Projectile newProjectile = Instantiate(projectile, projectileSpawns[i]);

                gunSound.PlayOneShot(shotSound);
            }
            
        }      

    }

    public void CoolDown()
    {

    }

}

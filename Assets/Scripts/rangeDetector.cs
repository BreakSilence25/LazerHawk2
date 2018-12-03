using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeDetector : MonoBehaviour
{

    public float maxDistance;
    public float currentDistance;

    public CoreBehaviour core;
    public WarningBehaviour warning;
    public Transform shipTransform;
    public AudioSource shipAudio;

    [SerializeField]
    private AudioClip warningSound;


	void Start ()
    {
        core = GetComponentInParent<CoreBehaviour>();
        warning = GameObject.Find("WarningSign").GetComponent<WarningBehaviour>();
        shipTransform = GameObject.Find("Ship").transform;
        shipAudio = GameObject.Find("Ship").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentDistance = Vector3.Distance(transform.position, shipTransform.position);

        if (currentDistance > maxDistance)
        {
            Debug.Log("too far away bro!");
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            warning.Warning();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (!shipAudio.isPlaying)
            {
                shipAudio.PlayOneShot(warningSound, 1f);
            }
            else
            {
                return;
            }
        }
    }
}

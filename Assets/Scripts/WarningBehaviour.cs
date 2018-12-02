using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningBehaviour : MonoBehaviour
{

    public Image warningImage;

    bool isAlreadyWarned = false;
	
	void Start ()
    {
        warningImage = GetComponent<Image>();

        warningImage.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    [ContextMenu("Start Warning")]
    public void Warning()
    {

        if (!isAlreadyWarned)
        {
            StartCoroutine(StartBlink());
        }
        else
        {
            return;
        }
    }

    IEnumerator StartBlink()
    {
        isAlreadyWarned = true;
        yield return new WaitForSeconds(0.5f);
        warningImage.enabled = true;
        yield return new WaitForSeconds(0.5f);
        warningImage.enabled = false;
        yield return new WaitForSeconds(0.5f);
        warningImage.enabled = true;
        yield return new WaitForSeconds(0.5f);
        warningImage.enabled = false;
        yield return new WaitForSeconds(0.5f);
        warningImage.enabled = true;
        yield return new WaitForSeconds(0.5f);
        warningImage.enabled = false;
        isAlreadyWarned = false;

        yield break;
    }

}

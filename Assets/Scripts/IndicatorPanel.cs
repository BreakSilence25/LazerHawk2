using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorPanel : MonoBehaviour
{

    public Image indicator;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        RenderIndicator();
	}

    void RenderIndicator()
    {
        EnemyBase[] objects = FindObjectsOfType(typeof(EnemyBase)) as EnemyBase[];

        foreach (EnemyBase obj in objects)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(obj.transform.position);

            if (screenPos.z > 0 && screenPos.x < Screen.width && screenPos.x > 0 && screenPos.y < Screen.height && screenPos.y > 0 && screenPos.z >= 0)
            {
                indicator.GetComponent<Image>().enabled = true;
                indicator.rectTransform.position = screenPos;
            }
            else
            {
                indicator.GetComponent<Image>().enabled = false;
            }
        }

    }

    void ClearPool()
    {
        GameObject[] indicators = GameObject.FindGameObjectsWithTag("Indicator");
        foreach (GameObject item in indicators)
        {
            Destroy(item);
        }
    }
}

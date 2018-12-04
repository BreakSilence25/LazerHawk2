using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIEnemyCount : MonoBehaviour
{

    public Text counterText;

	// Use this for initialization
	void Start ()
    {
        counterText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        TankBehaviour[] tanks = FindObjectsOfType(typeof(TankBehaviour)) as TankBehaviour[];

        counterText.text = "Enemies Left:" + tanks.Length.ToString();
    }
}

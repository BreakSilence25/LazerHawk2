﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
	void LateUpdate ()
    {
        gameObject.transform.Rotate(Vector3.up, 0.1f);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(GameObject.Find("[CameraRig]").transform);
    }
}

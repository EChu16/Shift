﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenChangeSceen : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)){
			Application.LoadLevel ("Bed Intro Level");


		}
	}
}

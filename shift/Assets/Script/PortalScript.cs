﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {
	public string leveltoload;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other){
		print ("in loop2");

		Application.LoadLevel (leveltoload);








	}
}

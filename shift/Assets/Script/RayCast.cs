﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {
	public GameObject projectile;
	public float range;
	public string tag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray landingRay = new Ray (transform.position, Camera.main.transform.forward);
		if (Physics.Raycast (landingRay, out hit, range)) {

			GameObject objectHit = hit.transform.gameObject;
			print(objectHit.tag);
			if (objectHit.tag == "enemy") {
				print ("yo");	
				Destroy (objectHit);


			Debug.DrawLine (transform.position, hit.point);
		}
	}
}
}

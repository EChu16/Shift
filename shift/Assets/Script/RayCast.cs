using System.Collections;
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
			Debug.DrawLine (transform.position, hit.point);
			GameObject objectHit = hit.transform.gameObject;
			if (objectHit.tag == "enemy") {
				print ("yo");	
				Destroy (objectHit);
				Destroy(gameObject);


			Debug.DrawLine (transform.position, hit.point);
		}
	}
}
}

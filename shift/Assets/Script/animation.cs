using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour {
	Animator anim;
	// Use this for initialization

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
	}
}

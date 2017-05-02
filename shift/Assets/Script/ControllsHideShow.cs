using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllsHideShow : MonoBehaviour {

	public GameObject GO;
	private bool change;
	private SpriteRenderer sprite_renderer;
	// Use this for initialization
	void Start () {
		sprite_renderer = GetComponent<SpriteRenderer> ();
		change = false;
	}

	// Update is called once per frame
	void Update () {


		if (change = true){
			sprite_renderer.enabled = false;

		}
	}

	private void OnTriggerStay(Collider other){
		print ("intrigger");
		if(Input.GetKey(KeyCode.Y))
			{
		change = true;

		}


		
	
	



	}
}



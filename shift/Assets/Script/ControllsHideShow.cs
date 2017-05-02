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


	

	
	}

	private void OnTriggerStay(Collider other){
		print ("in loop");
		if(Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.LeftArrow) ))
			{
			print ("sprite render");
			sprite_renderer.enabled = false;

		}

		if(Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.RightArrow) ))
		{
			print ("sprite render");
			sprite_renderer.enabled = false;

		}


		
	
	



	}
}



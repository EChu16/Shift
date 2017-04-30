using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorChangeLevel : MonoBehaviour {
	public string leveltoload; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerStay(Collider other){
		print ("intrigger");
		if (Input.GetKey(KeyCode.W)){ 
			print ("pressed W");
			Application.LoadLevel (leveltoload);
		
		}

	}


}

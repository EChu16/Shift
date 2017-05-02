using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorChangeLevel : MonoBehaviour {
	public string leveltoload; 
	private bool change;
	// Use this for initialization
	void Start () {
		change = false;
		
	}
	
	// Update is called once per frame
	void Update () {


		if (change = true){
		//float fadeTime = GameObject.Find ("Fade").GetComponent<Fading>().BeginFade (1);
		//yield return new WaitForSeconds (fadeTime);
		//Application.LoadLevel (Application.loadedLevel + 1);
		}
	}

	private void OnTriggerStay(Collider other){
		print ("intrigger");
		if (Input.GetKey(KeyCode.W)){ 
			print ("pressed W");
			change = true;
		


		Application.LoadLevel (leveltoload);
		
		}

	}


}

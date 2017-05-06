using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlayer : MonoBehaviour {
	public GameObject UI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnTriggerStay(Collider other){
		GameObject gameOverUI =  Instantiate (UI);
		gameOverUI.GetComponent<Canvas>().worldCamera = Camera.main;
		gameOverUI.GetComponent<Canvas> ().planeDistance = 10;
	


	}
}

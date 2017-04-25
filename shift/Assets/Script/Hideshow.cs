using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideshow : MonoBehaviour {
	Animator anim;
	public GameObject Ghost;
	public Transform EnemySpawn;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		print ("outside");
		if (Input.GetKey (KeyCode.E)) {
			print ("inside");
			anim.SetBool ("GhostSpawn ", true);
			Instantiate (Ghost, EnemySpawn.position, EnemySpawn.rotation);
		

		} else {
	
			anim.SetBool ("GhostSpawn ", false);

		
		}





	}
}

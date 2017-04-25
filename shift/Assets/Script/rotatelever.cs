using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

public class rotatelever : MonoBehaviour {
	public float turnspeed; 
	public bool shift; 
	private GameManager gm;
	public float delay;
	public GameObject player;
	private bool hasShifted;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
		shift = true;
		hasShifted = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E) && (shift == true) && !hasShifted && player.transform.position.x > -13  ) {
			transform.Rotate (Vector3.left, -turnspeed * Time.deltaTime);
			shift = false;


		}


		if (shift == false){
			if (delay > 0) { 
				delay -= Time.deltaTime;


			} else {
				
				gm.RotateWorldLeft ();
				shift = true;
				hasShifted = true;
			}
		}
	}


}

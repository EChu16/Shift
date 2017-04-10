﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {
  private Player player;
  private bool detectCollisions = true;

	// Use this for initialization
	void Start () {
	  player = transform.parent.GetComponent<Player> ();
	}

  public void enableTrigger() {
		detectCollisions = true;
  }

  public void disableTrigger() {
		detectCollisions = false;
  }

  void OnTriggerEnter(Collider col) {
		if (detectCollisions) {
			if (col.gameObject.tag == "enemy") {
				player.loseHealth (col.gameObject.GetComponent<Enemy> ().getCollisionDmg ());
			}
		}
  }

  void OnTriggerExit(Collider col) {}
}

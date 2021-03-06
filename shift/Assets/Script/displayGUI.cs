﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

public class displayGUI : MonoBehaviour {
  public GameObject heartPrefab;
  public GameObject levelHeader;
  private GameObject camera;
  private GameManager gm;
  public GameObject playerObj;
  private Player player;
  private int initialPlayerLives;
  private List<GameObject> playerLives;
  private Vector3 lastCameraPos;

	// Use this for initialization
	void Start () {
    player = playerObj.GetComponent<Player>();
    camera = Camera.main.gameObject;
    lastCameraPos = camera.transform.position;
    gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
    this.initialPlayerLives = (int)player.getHealth ();
    this.playerLives = new List<GameObject>();
    instantiatePlayerLifeIcons ();
    instantiateLevelHeader ();
    renderGUI (new Vector3(0,0,0));
	}

  // Instantiate heart icons for both players
  private void instantiatePlayerLifeIcons() {
    for (float i = 0; i < this.initialPlayerLives; i++) {
      this.playerLives.Add(Instantiate(heartPrefab, new Vector3(camera.transform.position.x - 3.4f + (i/3), camera.transform.position.y + 2f, camera.transform.position.z + 30f), heartPrefab.transform.rotation) as GameObject);
      this.playerLives [(int)i].transform.parent = Camera.main.transform;
    }
  }

  private void instantiateLevelHeader() {

  }

  // Update display when player loses life
  public void losePlayerLife() {
    Destroy(playerLives[playerLives.Count - 1]);
    playerLives.Remove(playerLives[playerLives.Count - 1]);
  }


  // Update display when player gains life
  public void gainPlayerLife(string player) {
    this.playerLives.Insert(0, Instantiate(heartPrefab, new Vector3(this.playerLives[0].transform.position.x + 0.25f, 5.2f, camera.transform.position.z), heartPrefab.transform.rotation) as GameObject);
  }

  private void renderGUI(Vector3 positionDiff) {
    gameObject.transform.Translate (positionDiff);
    lastCameraPos = camera.transform.position;
  }
	
	// Update is called once per frame
	void Update () {
    if (!player.isDead()) {
      renderGUI (new Vector3 (camera.transform.position.x - lastCameraPos.x, camera.transform.position.y - lastCameraPos.y, camera.transform.position.z - lastCameraPos.z));
    }
	}
}

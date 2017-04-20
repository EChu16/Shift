using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

public class MobSpawner : MonoBehaviour {
  private GameManager gm;
  public FacingDirection spawnInView;
  private bool spawned;
  public GameObject mob;
  private GameObject player;
  public float distanceTillActive;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
    player = GameObject.FindWithTag ("Player");
    spawned = false;
	}

  //Euclidean Distance
  private float distanceFromPlayer() {
    return Mathf.Sqrt (Mathf.Pow (player.transform.position.x - transform.position.x, 2f) + Mathf.Pow (player.transform.position.y - transform.position.y, 2f) + Mathf.Pow (player.transform.position.z - transform.position.z, 2f));
  }
	
  private void spawnMobIfOnPlane() {
    if (gm.getFacingDirection() == spawnInView && distanceFromPlayer() <= distanceTillActive) {
      var enemy = Instantiate (mob, new Vector3(transform.position.x-1f, transform.position.y+.5f, transform.position.z), transform.rotation);
      enemy.GetComponent<Enemy>().setChosenDirection (spawnInView);
      this.spawned = true;
    }
  }

	// Update is called once per frame
	void Update () {
		if (!this.spawned) {
      spawnMobIfOnPlane();
    }
	}
}

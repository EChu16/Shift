using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideshow : MonoBehaviour {
	Animator anim;
	public GameObject Ghost;
	public Transform EnemySpawn;
  private float delay = 1.2f;
  private bool hasSpawn = false;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();

	}

  public void spawnAnim() {
    if (this.delay > 0) {
      this.delay -= Time.deltaTime;
    } else {
      anim.SetBool ("GhostSpawn ", true);
      Instantiate (Ghost, EnemySpawn.position, EnemySpawn.rotation);
    }
    if (hasSpawn) {
      anim.SetBool ("GhostSpawn ", false);
    }
  }
	
	// Update is called once per frame
	void Update () {

	}
}

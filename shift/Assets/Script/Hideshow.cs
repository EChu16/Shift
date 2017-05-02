using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideshow : MonoBehaviour {
	Animator anim;
	public GameObject Ghost;
	public Transform EnemySpawn;
  private float delay = 1.2f;
  private bool hasSpawn = false;
	public MobSpawner spawner;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();

	}

  public void spawnAnim() {
		spawner.SpawnENEMY ();
  }
	
	// Update is called once per frame
	void Update () {

	}
}

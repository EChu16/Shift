using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideshow : MonoBehaviour {
	Animator anim;
	public GameObject Ghost;
	public Transform EnemySpawn;
  private float delay = 1.2f;
	private bool hasSpawn = true;

	public MobSpawner spawner;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool("spawn", true);
	}

  public void spawnAnim() {

		print ("spawnanim");
		Debug.Log (hasSpawn);
		if (hasSpawn){
			anim.SetBool("spawn", false);
			Debug.Log (hasSpawn);
		spawner.SpawnENEMY ();


			hasSpawn = false;
		}
  }
	
	// Update is called once per frame
	void Update () {

	}
}

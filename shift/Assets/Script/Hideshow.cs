using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

public class Hideshow : MonoBehaviour {
	Animator anim;
	public GameObject Ghost;
	private GameManager gm;
	public Transform EnemySpawn;
  private float delay = 1.2f;
	private bool hasSpawn = true;
	public FacingDirection spawnInView;
	public float distanceTillActive;
	private GameObject player;
	private bool playAnim;


	public MobSpawner spawner;
	// Use this for initialization
	void Start () {
		gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
		player = GameObject.FindWithTag ("Player");
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool("spawn", false);
		hasSpawn = true;
	}

	private float distanceFromPlayer() {
		return Mathf.Sqrt (Mathf.Pow (player.transform.position.x - transform.position.x, 2f) + Mathf.Pow (player.transform.position.y - transform.position.y, 2f) + Mathf.Pow (player.transform.position.z - transform.position.z, 2f));
	}

  public void spawnAnim() {
		
		if (gm.getFacingDirection () == spawnInView && distanceFromPlayer () <= distanceTillActive) {
			print ("inloop");
		

			if (hasSpawn) {
				print ("here");
				anim.SetBool ("spawn", true);

				if (delay < 0) {
					spawner.SpawnENEMY ();
					hasSpawn = false;
				} else {

					delay -= Time.deltaTime;


				}


			}
		}
	}
	// Update is called once per frame
	void Update () {
		//if (playAnim) {
			spawnAnim ();
		//}

	}
}

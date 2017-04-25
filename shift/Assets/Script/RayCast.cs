using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

public class RayCast : MonoBehaviour {
	public GameObject projectile;
  private GameManager gm;
	public float range;
	public string tag;
	// Use this for initialization
	void Start () {
    gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray landingRay = new Ray (transform.position, Camera.main.transform.forward);
		if (Physics.Raycast (landingRay, out hit, range)) {
			GameObject objectHit = hit.transform.gameObject;
			if (objectHit.tag == "enemy") {
        float dmg = projectile.GetComponent<ProjectileController> ().getBaseAttack ();
        Enemy foe = objectHit.gameObject.GetComponent<Enemy> ();
        if (foe.getType () == Mob.KNIGHT) {
          if (gm.getFacingDirection () == foe.getChosenDir1 () || gm.getFacingDirection () == foe.getChosenDir2 ()) {
            dmg = 0f;
          }
        }
				objectHit.gameObject.GetComponent<Enemy>().loseLife(dmg);
				Destroy(gameObject);
			}
		}
	}
}

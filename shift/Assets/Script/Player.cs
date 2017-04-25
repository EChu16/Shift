using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private float healthPoints;
  private float knockbackForce;
  private PlayerTrigger pt;
  private float baseAttack;
	public GameObject UI;
	// Use this for initialization
	void Start () {
    this.healthPoints = 3.0f;
    this.baseAttack = 1.0f;
    pt = gameObject.GetComponentInChildren<PlayerTrigger> ();
	}

  public float getHealth() {
    return healthPoints;
  }

  public void loseHealth(float hp) {
    this.healthPoints -= hp;
  }

  public bool isDead() {
    return this.healthPoints == 0;
  }

  public void enableHitBox() {
    pt.enableTrigger ();
  }
  public void disableHitBox() {
    pt.disableTrigger ();
  }

  public float getBaseAttack() {
    return this.baseAttack;
  }

  public void incrementBaseAtk(float newAtk) {
    this.baseAttack += newAtk;
  }
	
	// Update is called once per frame
	void Update () {
    if (this.isDead ()) {
      //Destroy (gameObject);
			print ("YOU IS DEAD");
			Instantiate(UI);
    }
	}
}

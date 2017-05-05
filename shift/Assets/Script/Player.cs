using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private float healthPoints = 3.0f;
  private float knockbackForce;
  private PlayerTrigger pt;
  private float baseAttack;
  private float attackSpeed;
	public GameObject UI;
  private bool gameOverScreenDisplaying;
  private displayGUI dg;

	// Use this for initialization
	void Start () {
    this.baseAttack = 1.0f;
    this.attackSpeed = 3.0f;
    pt = gameObject.GetComponentInChildren<PlayerTrigger> ();
    dg = GameObject.FindWithTag ("displayGUI").GetComponent<displayGUI>();
    this.gameOverScreenDisplaying = false;
	}

  public float getHealth() {
    return healthPoints;
  }

  public void loseHealth(float hp) {
    this.healthPoints -= hp;

    dg.losePlayerLife ();
  }

  public bool isDead() {
    return this.healthPoints <= 0;
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

  public float getAttackSpeed() {
    return this.attackSpeed;
  }

  public void incrementAttackSpeed(float newAtkSpeed) {
    this.attackSpeed += newAtkSpeed;
  }
	
	// Update is called once per frame
	void Update () {
    if (this.isDead ()) {
      //Destroy (gameObject);
      if (!gameOverScreenDisplaying) {
        Instantiate (UI);
      }
      gameOverScreenDisplaying = true;
    }
	}
}

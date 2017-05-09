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
	public GameObject otherObject;
	Animator otherAnimator;
	public float Delay;
	public bool Delaybool;
	SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		Delaybool = true; 


		renderer = otherObject.GetComponent<SpriteRenderer>(); 
		
		Delay = 4f;
				
    this.baseAttack = 1.0f;
    this.attackSpeed = 3.0f;
		otherAnimator = otherObject.GetComponent<Animator> ();
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
		while (Delaybool == true) {
			if (Delay < 1.1) {  
				renderer.color = new Color (10, 1, 0);
				Delaybool = false;
			} else {
				renderer.color = new Color (0, 0, 0);
				print (Delay);
				Delay -= Time.deltaTime;

			}
		}
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
				GameObject gameOverUI =  Instantiate (UI);
				gameOverUI.GetComponent<Canvas>().worldCamera = Camera.main;
				gameOverUI.GetComponent<Canvas> ().planeDistance = 10;
      }
      gameOverScreenDisplaying = true;
    }
	}
}

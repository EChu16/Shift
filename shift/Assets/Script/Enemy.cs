using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

public enum Mob {
  SLIME = 0
}

public class Enemy : MonoBehaviour {
  public Mob id;
  private GameManager gm;
  private GameObject player;
  private float focusAxesPosition;
  private float collisionDmg;
  private int currentDirection = -1;
  private float walkExpTime = 3f;
  private float hp;
  private float movementSpeed;
  private FacingDirection lastFacingDir;

	// Use this for initialization
	void Start () {
    gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
    updateEnemyStats ();
	}

  private void updateEnemyStats() {
    if (this.id == Mob.SLIME) {
      this.hp = 2.0f;
      this.movementSpeed = .5f;
      this.collisionDmg = 1.0f;
    }
  }

  public float getCollisionDmg() {
    return collisionDmg;
  }

  private void moveEnemyOn(char axis) {
    var moveFactor = currentDirection * movementSpeed * Time.deltaTime;
    if (axis == 'x') {
      if (this.id == Mob.SLIME) {
        transform.position = new Vector3 (this.transform.position.x + moveFactor, this.transform.position.y, this.transform.position.z);
      }
    } else {
      if (this.id == Mob.SLIME) {
        transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + moveFactor);
      }
    }
  }

  private void updateEnemyAI() {
    if (this.id == Mob.SLIME) {
      if (this.walkExpTime <= 0) {
        currentDirection *= -1;
        walkExpTime = 3f;
        transform.RotateAround(transform.position, transform.up, 180f);
      } else {
        walkExpTime -= Time.deltaTime;
      }
    }
    var facingDir = gm.getFacingDirection ();
    if (facingDir == FacingDirection.Front || facingDir == FacingDirection.Back) {
      moveEnemyOn ('x');
    } else {
      moveEnemyOn ('z');
    }
    if(lastFacingDir != facingDir) {
      transform.RotateAround(transform.position, transform.up, 180f);
    }
    lastFacingDir = facingDir;
  }

	// Update is called once per frame
	void Update () {
    updateEnemyAI ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

public enum Mob {
  SLIME = 0,
  KNIGHT = 1,
  BED_MONSTER = 2
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
  private bool isHit = false;
  private float hitExpTime;
  private FacingDirection chosenDirection;
  private bool isVisible;
	public GameObject coin; 
	// Use this for initialization
	void Start () {
    gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
    player = GameObject.FindWithTag ("Player");
    updateEnemyStats ();
	}

  public void setChosenDirection(FacingDirection dir) {
    chosenDirection = dir;
  }

  private int isPlayerLeftOrRight() {
    FacingDirection worldDir = gm.getFacingDirection ();
    if (worldDir == FacingDirection.Front || worldDir == FacingDirection.Back) {
      if (transform.position.x <= player.transform.position.x) {
        return 1;
      } else {
        return -1;
      }
    } else {
      if (transform.position.z <= player.transform.position.z) {
        return 1;
      } else {
        return -1;
      }
    }
  }

  private void updateEnemyStats() {
    if (this.id == Mob.SLIME) {
      this.hp = 2.0f;
      this.movementSpeed = .5f;
      this.collisionDmg = 1.0f;
      // set this.AnimController = "";
    } else if(this.id == Mob.BED_MONSTER) {
      this.hp = 4.0f;
      this.movementSpeed = .5f;
      this.collisionDmg = 1.0f;
    }
  }

  public float getCollisionDmg() {
    return collisionDmg;
  }

  //Euclidean Distance
  private float distanceFromPlayer() {
    return Mathf.Sqrt (Mathf.Pow (player.transform.position.x - transform.position.x, 2f) + Mathf.Pow (player.transform.position.y - transform.position.y, 2f) + Mathf.Pow (player.transform.position.z - transform.position.z, 2f));
  }

  private void moveEnemyOn(char axis) {
    var moveFactor = currentDirection * movementSpeed * Time.deltaTime;
    if (axis == 'x') {
      if (this.id == Mob.SLIME || this.id == Mob.BED_MONSTER) {
        transform.position = new Vector3 (this.transform.position.x + moveFactor, this.transform.position.y, this.transform.position.z);
      }
    } else {
      if (this.id == Mob.SLIME || this.id == Mob.BED_MONSTER) {
        transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + moveFactor);
      }
    }
  }

  private void updateEnemyAI() {
    // Get Facing Direction
    var facingDir = gm.getFacingDirection ();

    // Slime AI
    if (this.id == Mob.SLIME) {
      // Hit effect
      if (this.isHit) {
        this.hitExpTime -= Time.deltaTime;
        //Set anim hit
        if (this.hitExpTime <= 0) {
          this.isHit = false;
          //Set anim normal
        }
      }
      // Move effect
      if (this.walkExpTime <= 0) {
        currentDirection *= -1;
        walkExpTime = 3f;
        transform.RotateAround (transform.position, transform.up, 180f);
      } else {
        walkExpTime -= Time.deltaTime;
      }
      // Rotating for slimes
      if(lastFacingDir != facingDir) {
        transform.RotateAround(transform.position, transform.up, 180f);
      }

      // Bed Monster AI
    } else if (this.id == Mob.BED_MONSTER) {
      // Hit effect
      if (this.isHit) {
        this.hitExpTime -= Time.deltaTime;
        //Set anim hit
        if (this.hitExpTime <= 0) {
          this.isHit = false;
        }
      }
      // Move effect
      if (gm.getFacingDirection () == this.chosenDirection) {
    
        this.isVisible = false;
      } else {
      
        this.isVisible = true;
      }
      if (this.isVisible) {
        currentDirection = isPlayerLeftOrRight ();
      }
    }

    // General Movement
    if (facingDir == FacingDirection.Front || facingDir == FacingDirection.Back) {
      moveEnemyOn ('x');
    } else {
      moveEnemyOn ('z');
    }
    lastFacingDir = facingDir;
  }

  public void loseLife(float amt) {
    this.hp -= amt;
    this.isHit = true;
    this.hitExpTime = 0.8f;
  }

  public bool isHittable() {
    return this.isVisible;
  }

  private bool isDead() {
    return this.hp <= 0.0f;
  }

  private Mob getType() {
    return this.id;
  }

  private void enemyDieAnimation() {
    // enemy die here
    Destroy(gameObject);
  }

	// Update is called once per frame
	void Update () {
    updateEnemyAI ();
    if(isDead()) {
      enemyDieAnimation();
			Instantiate (coin, transform.position, transform.rotation);	 
    }
	}
}

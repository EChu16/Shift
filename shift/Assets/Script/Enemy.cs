using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

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
  public FacingDirection chosenDirection;
  public FacingDirection chosenDirection2;
  private bool isVisible;
	public GameObject coin; 
  private int newDirection;
  private bool isAttacking;
  private float attackTime;
  private float attackRange;

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
    } else if (this.id == Mob.KNIGHT) {
      this.hp = 3.0f;
      this.movementSpeed = 2.0f;
      this.collisionDmg = 1.0f;
      this.attackRange = 1.0f;
      // Shield planes
      this.chosenDirection = FacingDirection.Front;
    } else if(this.id == Mob.BED_MONSTER) {
      this.hp = 4.0f;
      this.movementSpeed = .5f;
      this.collisionDmg = 2.0f;
    }
    this.isAttacking = false;
  }

  public float getCollisionDmg() {
    return collisionDmg;
  }

  public Mob getType() {
    return this.id;
  }

  public FacingDirection getChosenDir1() {
    return this.chosenDirection;
  }

  public FacingDirection getChosenDir2() {
    return this.chosenDirection2;
  }

  //Euclidean Distance 3D Space
  private float distanceFromPlayer() {
    return Mathf.Sqrt (Mathf.Pow (player.transform.position.x - transform.position.x, 2f) + Mathf.Pow (player.transform.position.y - transform.position.y, 2f) + Mathf.Pow (player.transform.position.z - transform.position.z, 2f));
  }

  //Distance Formula 2D Space
  private float flatDistanceFromPlayer() {
    var facingDir = gm.getFacingDirection ();
    if (facingDir == FacingDirection.Front || facingDir == FacingDirection.Back) {
      return Mathf.Sqrt (Mathf.Pow (player.transform.position.x - transform.position.x, 2f) + Mathf.Pow (player.transform.position.y - transform.position.y, 2f));
    } else {
      return Mathf.Sqrt (Mathf.Pow (player.transform.position.z - transform.position.z, 2f) + Mathf.Pow (player.transform.position.y - transform.position.y, 2f));
    }
  }

  private void moveEnemyOn(char axis) {
    var moveFactor = currentDirection * movementSpeed * Time.deltaTime;
    if (this.id == Mob.SLIME) {
      transform.position = new Vector3 (this.transform.position.x + moveFactor, this.transform.position.y, this.transform.position.z + moveFactor);
    }
    if (axis == 'x') {
      if (this.id == Mob.BED_MONSTER || this.id == Mob.KNIGHT) {
        transform.position = new Vector3 (this.transform.position.x + moveFactor, this.transform.position.y, this.transform.position.z);
      }
    } else {
      if (this.id == Mob.BED_MONSTER || this.id == Mob.KNIGHT) {
        transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + moveFactor);
      }
    }
  }

  private void displayHitAnimIfHit() {
    if (this.isHit) {
      this.hitExpTime -= Time.deltaTime;
      //Set anim hit
      if (this.hitExpTime <= 0) {
        this.isHit = false;
        // Set anim normal
      }
    }
  }

  private void updateEnemyAI() {
    // Get Facing Direction
    var facingDir = gm.getFacingDirection ();

    // Slime AI
    if (this.id == Mob.SLIME) {
      displayHitAnimIfHit ();
      // Move effect
      if (this.walkExpTime <= 0) {
        currentDirection *= -1;
        walkExpTime = 3f;
        transform.RotateAround (transform.position, transform.up, 180f);
      } else {
        walkExpTime -= Time.deltaTime;
      }
      // Rotating for slimes
      if (lastFacingDir != facingDir) {
        transform.RotateAround (transform.position, transform.up, 180f);
      }

      // Knight AI
    } else if (this.id == Mob.KNIGHT) {
      // Hit Effect
      displayHitAnimIfHit ();
      int newDirection = isPlayerLeftOrRight ();
      if (currentDirection != newDirection) {
        transform.RotateAround (transform.position, transform.up, 180f);
        currentDirection = newDirection;
      }

      float dist = flatDistanceFromPlayer ();
      if ((this.chosenDirection == facingDir)) {
        this.movementSpeed = 0f;
      } else if(dist <= 5f){
        this.movementSpeed = 1f;
      }

      if (dist <= 0.5f && !isAttacking) {
        Vector3 size = GetComponent<BoxCollider> ().size;
        //attack AI
        GetComponent<BoxCollider>().size = new Vector3(size.x + this.attackRange, size.y, size.z + this.attackRange);
        isAttacking = true;
        attackTime = 2f;
      }

      if (isAttacking) {
        if (attackTime > 0) {
          attackTime -= Time.deltaTime;
        } else {
          Vector3 size = GetComponent<BoxCollider> ().size;
          isAttacking = false;
          GetComponent<BoxCollider> ().size = new Vector3 (size.x - this.attackRange, size.y, size.z - this.attackRange);
        }
      } else {
        newDirection = isPlayerLeftOrRight ();
        if (currentDirection != newDirection) {
          transform.RotateAround (transform.position, transform.up, 180f);
          currentDirection = newDirection;
        }
      }

      // Bed Monster AI
    } else if (this.id == Mob.BED_MONSTER) {
      displayHitAnimIfHit ();
      // Move effect
      newDirection = isPlayerLeftOrRight ();
      if (currentDirection != newDirection) {
        transform.RotateAround (transform.position, transform.up, 180f);
        currentDirection = newDirection;
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

  private void enemyDieAnimation() {
    // enemy die here
    Destroy(gameObject);
  }

	// Update is called once per frame
	void Update () {
    updateEnemyAI ();
    if(isDead()) {
      enemyDieAnimation();
			Instantiate (coin, transform.position, Quaternion.identity);	 
    }
	}
}

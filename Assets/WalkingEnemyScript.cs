using UnityEngine;

public class WalkingEnemyScript : MonoBehaviour
{
  private Rigidbody2D rb2D;

  private float xOrigin;

  private bool chaseEnemy;
  private bool facingRight;

  public float maximumSteps;
  public float walkSpeed;
  public float chaseSpeed;
  public float lineOfSight;

  Vector2 directionToPlayer;

  public Rigidbody2D playerRb;

  void Start() {
    rb2D = gameObject.GetComponent<Rigidbody2D>();
    xOrigin = rb2D.position.x;
    chaseEnemy = false;
    facingRight = true;
  }

  void Update() {
    directionToPlayer = new Vector2(playerRb.position.x - rb2D.position.x, playerRb.position.y - rb2D.position.y);
    if (Mathf.Abs(directionToPlayer.x) < lineOfSight && Mathf.Abs(directionToPlayer.y) < 1) {
      chaseEnemy = true;
    }
    else {
      chaseEnemy = false;
    }
  }

  void FixedUpdate() {
    if (chaseEnemy) {
      if (directionToPlayer.x > 0) {
        if (!facingRight) {
          Flip();
        }
        rb2D.MovePosition(rb2D.position + new Vector2(1, 0) * chaseSpeed * Time.deltaTime);
      }
      else {
        if (facingRight) {
          Flip();
        }
        rb2D.MovePosition(rb2D.position + new Vector2(-1, 0) * chaseSpeed * Time.deltaTime);
      }
      if (Mathf.Abs(rb2D.position.x - xOrigin) > maximumSteps) {
        xOrigin = rb2D.position.x;
      }
    } else {
      Patrol();
    }
  }

  void Patrol() {
    Debug.Log(rb2D.position.x - xOrigin);
    if (Mathf.Abs(rb2D.position.x - xOrigin) > maximumSteps) {
      Flip();
    }
    rb2D.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb2D.velocity.y);
  }

  void Flip() {
    facingRight = !facingRight;
    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    walkSpeed *= -1;
  }
}

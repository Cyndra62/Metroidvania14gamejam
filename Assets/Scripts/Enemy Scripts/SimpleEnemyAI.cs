using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour {
  public float walkSpeed;
  public float health;

  [HideInInspector]
  public bool mustPatrol;
  private bool mustTurn;

  public new Rigidbody2D rigidbody;
  public Transform groundCheckPos;
  public LayerMask groundLayer;
  public Collider2D bodyCollider;

  void Start() {
    mustPatrol = true;
  }

  void Update() {
    if (health == 0)
    {
      Destroy(gameObject);
    }
    if (mustPatrol) {
      Patrol();
    }
  }

  private void FixedUpdate() {
    if (mustPatrol) {
      mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
    }
  }

  void Patrol() {
    if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer)) {
      Flip();
    }
    rigidbody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rigidbody.velocity.y);
  }

  void Flip() {
    mustPatrol = false;
    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    walkSpeed *= -1;
    mustPatrol = true;
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Bullet"))
    {
      health -= 1;
    }
  }

}

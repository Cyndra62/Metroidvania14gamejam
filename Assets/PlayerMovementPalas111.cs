using UnityEngine;

public class PlayerMovementPalas111 : MonoBehaviour
{

  public float movementSpeed;
  public float jumpForce;

  private bool isJumping;
  private float moveHorizontal;
  private float moveVertical;

  private Rigidbody2D _rigidbody;

    void Start() {
      _rigidbody = gameObject.GetComponent<Rigidbody2D>();

      isJumping = false;
    }

    void Update() {
      moveHorizontal = Input.GetAxisRaw("Horizontal");
      moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
      if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) {
        _rigidbody.AddForce(new Vector2(moveHorizontal * movementSpeed, 0f), ForceMode2D.Impulse);
      }
      if (!isJumping && moveVertical > 0.1f) {
        _rigidbody.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
      }

    }

    void OnTriggerEnter2D(Collider2D collision) {
      if (collision.gameObject.tag == "Platform") {
        isJumping = false;
      }
    }

    void OnTriggerExit2D(Collider2D collision) {
      if (collision.gameObject.tag == "Platform") {
        isJumping = true;
      }
    }
}

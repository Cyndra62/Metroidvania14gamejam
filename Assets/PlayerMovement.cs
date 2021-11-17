using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  public float movementSpeed;
  public float jumpForce;

  private Rigidbody2D rigidbody;

    void Start() {
      rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
      var movement = Input.GetAxis("Horizontal");
      transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

      if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.01) {
        rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
      }
    }
}

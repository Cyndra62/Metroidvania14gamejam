using UnityEngine;
using UnityEngine.Serialization;

public class ChasingEnemyAI : MonoBehaviour
{
  private Rigidbody2D _rigidbody;

  private float _xOrigin;

  private bool _chaseEnemy;
  private bool _facingRight;

  public float maximumSteps;
  public float walkSpeed;
  public float chaseSpeed;
  public float lineOfSight;

  private Vector2 _directionToPlayer;
  
  public Rigidbody2D playerRb;

  void Start()
  {
    _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    _xOrigin = _rigidbody.position.x;
    _chaseEnemy = false;
    _facingRight = true;
  }

  void Update() 
  {
    _directionToPlayer = playerRb.position - _rigidbody.position;
    Debug.Log(_directionToPlayer.x);
    if (Mathf.Abs(_directionToPlayer.x) < lineOfSight && Mathf.Abs(_directionToPlayer.y) < 1)
    {
      _chaseEnemy = true;
    }
    else if (_chaseEnemy)
    {
      _chaseEnemy = false;
    }
  }

  void FixedUpdate()
  {
    if (_chaseEnemy)
    {
      ChaseEnemy();
    }
    else
    {
      Patrol();
    }
  }

  private void ChaseEnemy() {
    if (_directionToPlayer.x > 0 && !_facingRight)
    {
      Flip();
    }
    else if (_directionToPlayer.x < 0 && _facingRight)
    {
      Flip();
    }
    _rigidbody.MovePosition(_rigidbody.position + new Vector2(_directionToPlayer.normalized.x, 0) * chaseSpeed * Time.deltaTime);
    if (Mathf.Abs(_rigidbody.position.x - _xOrigin) > maximumSteps)
    {
      _xOrigin = _rigidbody.position.x;
    }
  }

  private void Patrol()
  {
    if (Mathf.Abs(_rigidbody.position.x - _xOrigin) > maximumSteps)
    {
      Flip();
    }
    _rigidbody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);
  }

  private void Flip()
  {
    _facingRight = !_facingRight;
    transform.localScale *= new Vector2(-1, 1);
    walkSpeed *= -1;
  }
}

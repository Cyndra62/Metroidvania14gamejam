using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public static PlayerControl instance;

    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    public bool canMove;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer theSpritePlayer;
    public Transform thePlayer;

    public GameObject laser;
    public Transform laserPoint;
    private float laserSpeed;
    public float timeBetweenLaserShots;
    private float laserShotCounter;

    public float bounceBackLenght, bounceZero, bounceBackForce, bounceUpForce;
    private float bounceBackCounter;

    public int currentLaserLife, maxLaserLife;
    public float resetLaserTime;
    private float resetLaserCounter;
    public float regenLaserTime;
    private float regenLaserCounter;



    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        theSpritePlayer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        canMove = true;
        currentLaserLife = maxLaserLife;
        thePlayer.parent = null;
    }


    void Update()
    {
        if (canMove)
        {
            if (bounceBackCounter <= 0)
            {
                theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);

                isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

                if (isGrounded)
                {
                    canDoubleJump = true;
                }


                if (Input.GetButtonDown("Jump"))
                {
                    
                    if (isGrounded)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    }
                    else if (canDoubleJump)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        canDoubleJump = false;
                    }
                }

                if (theRB.velocity.x > 0)
                {
                    thePlayer.transform.localScale = new Vector3(-2, 2, 2);
                }
                else if (theRB.velocity.x < 0)
                {
                    thePlayer.transform.localScale = new Vector3(2, 2, 2);
                }
                /*
                if (laserShotCounter > 0)
                {
                    laserShotCounter -= Time.deltaTime;
                }

                if (regenLaserCounter > 0)
                {
                    regenLaserCounter -= Time.deltaTime;

                    if (regenLaserCounter <= 0)
                    {
                        currentLaserLife++;
                        regenLaserCounter = regenLaserTime;
                        LevelManager.instance.currentRecharge++;
                        LaserUI.instance.UpdateLaserRecharge();

                        if (currentLaserLife > maxLaserLife)
                        {
                            currentLaserLife = maxLaserLife;
                            LevelManager.instance.currentRecharge = maxLaserLife;
                            LaserUI.instance.UpdateLaserRecharge();
                        }
                    }
                }

                if (resetLaserCounter > 0)
                {
                    resetLaserCounter -= Time.deltaTime;
                    if (resetLaserCounter <= 0)
                    {
                        currentLaserLife = maxLaserLife;
                        laserShotCounter = timeBetweenLaserShots;
                        LevelManager.instance.currentRecharge = maxLaserLife;
                        LaserUI.instance.UpdateLaserRecharge();
                    }
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (laserShotCounter <= 0)
                    {
                        laserShotCounter = timeBetweenLaserShots;
                        TheLaser();
                        currentLaserLife--;
                        regenLaserCounter = regenLaserTime;
                        LevelManager.instance.currentRecharge--;
                        LaserUI.instance.UpdateLaserRecharge();

                        if (currentLaserLife <= 0)
                        {
                            resetLaserCounter = resetLaserTime;
                            laserShotCounter = resetLaserTime;
                            regenLaserCounter = resetLaserTime;
                        }
                    }
                }*/
                anim.SetBool("isGrounded", true);
                if (theRB.velocity.y < 0)
                {
                    anim.SetTrigger("falling");
                    anim.SetBool("isGrounded", false);
                }
            }
            else
            {
                bounceBackCounter -= Time.deltaTime;

            }


            anim.SetFloat("MoveSpeed", Mathf.Abs(theRB.velocity.x));
            

            

        }
        else
        {
            anim.SetFloat("MoveSpeed", theRB.velocity.x);
            theRB.velocity = Vector2.zero;
        }
    }

    public void BounceBack()
    {
        bounceBackCounter = bounceBackLenght;
        theRB.velocity = new Vector2(bounceBackForce, bounceUpForce);
        anim.SetTrigger("hurt");
    }

    public void BounceUp()
    {
        bounceBackCounter = bounceBackLenght;
        theRB.velocity = new Vector2(bounceZero, bounceUpForce);
    }

    public void TheLaser()
    {
        GameObject newLaser = Instantiate(laser, laserPoint.position, laserPoint.rotation);
        newLaser.transform.localScale = thePlayer.localScale;
        Destroy(newLaser, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (transform.position.x > other.transform.position.x)
            {
                theRB.velocity = new Vector2(bounceBackForce, theRB.velocity.y);
            }
            else if (transform.position.x < other.transform.position.x)
            {
                theRB.velocity = new Vector2(-bounceBackForce, theRB.velocity.y);
            }
        }
    }
}

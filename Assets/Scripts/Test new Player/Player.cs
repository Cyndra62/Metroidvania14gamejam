using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [Header("Gate System")]
    public string areaTransitionName;

    [Header("Player Controll")]
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D theRB;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    private Animator anim;
    public Transform theSR;
    public bool stopInput;
    public float knockBackLenght, bounceForce, knockUpForce, knockBackForce;
    private float knockBackCounter;
    public SpriteRenderer playerDeath;

    [Header("Shooting system")]
    public Transform shootingPoint;
    public SpriteRenderer haloColor;
    public GameObject haloGreenBullet;
    public GameObject haloRedBullet;
    public GameObject haloBlueBullet;
    public Transform haloGreenBullet1;
    public Transform haloRedBullet1;
    public Transform haloBlueBullet1;
    public float waitToShoot;
    private float counterToWait;
    private bool canShoot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }

        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        canShoot = true;
        counterToWait = waitToShoot;
        anim = GetComponent<Animator>();
        haloColor.color = new Color(1, 0, 0, 1);
        //theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!stopInput)
        {
            if (knockBackCounter <= 0)
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
                    else
                    {
                        if (canDoubleJump)
                        {
                            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                            canDoubleJump = false;
                        }
                    }
                }

                if (theRB.velocity.x < 0)
                {
                    theSR.transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (theRB.velocity.x > 0)
                {
                    theSR.transform.localScale = new Vector3(1, 1, 1);
                }

                anim.SetBool("isGrounded", isGrounded);
                anim.SetFloat("move", Mathf.Abs(theRB.velocity.x));

                /*if(theRB.velocity.y < 0)
                {
                    anim.SetTrigger("falling");
                }*/

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    IsSavedScene.instance.redOff = false;
                    IsSavedScene.instance.greenOff = true;
                    IsSavedScene.instance.blueOff = true;
                    haloColor.color = new Color(1, 0, 0, 1);

                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    IsSavedScene.instance.redOff = true;
                    IsSavedScene.instance.greenOff = false;
                    IsSavedScene.instance.blueOff = true;
                    haloColor.color = new Color(0, 1, 0, 1);
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    IsSavedScene.instance.redOff = true;
                    IsSavedScene.instance.greenOff = true;
                    IsSavedScene.instance.blueOff = false;
                    haloColor.color = new Color(1, 1, 1, 1);
                }
                if (counterToWait > 0)
                {
                    counterToWait -= Time.deltaTime;
                    if (counterToWait <= 0)
                    {
                        canShoot = true;

                    }
                }

                if (Input.GetKeyDown(KeyCode.K) && canShoot)
                {
                    canShoot = false;
                    counterToWait = waitToShoot;
                    if (!IsSavedScene.instance.redOff)
                    {
                        if (theSR.transform.localScale == new Vector3(-1, 1, 1))
                        {
                            haloRedBullet1.transform.localScale = new Vector3(1.3f, 1.3f, 1);
                            Instantiate(haloRedBullet, shootingPoint.position, shootingPoint.rotation);

                        }
                        else if (theSR.transform.localScale == new Vector3(1, 1, 1))
                        {
                            haloRedBullet1.transform.localScale = new Vector3(-1.3f, 1.3f, 1);
                            Instantiate(haloRedBullet, shootingPoint.position, shootingPoint.rotation);
                        }
                    }
                    if (!IsSavedScene.instance.greenOff)
                    {
                        if (theSR.transform.localScale == new Vector3(-1, 1, 1))
                        {
                            haloGreenBullet1.transform.localScale = new Vector3(1.3f, 1.3f, 1);
                            Instantiate(haloGreenBullet, shootingPoint.position, shootingPoint.rotation);

                        }
                        else if (theSR.transform.localScale == new Vector3(1, 1, 1))
                        {
                            haloGreenBullet1.transform.localScale = new Vector3(-1.3f, 1.3f, 1);
                            Instantiate(haloGreenBullet, shootingPoint.position, shootingPoint.rotation);
                        }

                    }
                    if (!IsSavedScene.instance.blueOff)
                    {

                        if (theSR.transform.localScale == new Vector3(-1, 1, 1))
                        {
                            haloBlueBullet1.transform.localScale = new Vector3(1.3f, 1.3f, 1);
                            Instantiate(haloBlueBullet, shootingPoint.position, shootingPoint.rotation);

                        }
                        else if (theSR.transform.localScale == new Vector3(1, 1, 1))
                        {
                            haloBlueBullet1.transform.localScale = new Vector3(-1.3f, 1.3f, 1);
                            Instantiate(haloBlueBullet, shootingPoint.position, shootingPoint.rotation);
                        }
                    }
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime;

                
                if (theSR.transform.localScale == new Vector3(-1, 1, 1))
                {
                    theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
                }
                else
                {
                    theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
                }
            }
        }
    }

    
    public void KnockBack()
    {
        knockBackCounter = knockBackLenght;
        theRB.velocity = new Vector2(0f, knockUpForce);
        anim.SetTrigger("hurt");
    }

    public void Bounce()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
        //AudioManager.instance.PlaySFX(13);
    }

}

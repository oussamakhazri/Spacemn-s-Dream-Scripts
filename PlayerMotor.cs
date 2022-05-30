using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{


    public float moveSpeed;
    public float jumpForce;
    private int extraJumps;
    public int extraJumpValue;
    private bool facingRight = true;
    private float moveInput;
    private float vertical;
    private bool isLadder;
    private bool isClimbing;
    [SerializeField] ParticleSystem DeathFX = null;



    Animator anim;
    Rigidbody2D rb;

    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private BoxCollider2D boxCollider2d;


    private void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();

    }





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        extraJumps = extraJumpValue;

    }

    // Update is called once per frame
    void Update()
    {





        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
           
        }
        else
        {
            anim.SetBool("isRunning", true);
            FindObjectOfType<AudioManager>().Play("Walk");
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        Jump();

        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;

        }
        
       
      

      

    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * moveSpeed);
            anim.SetBool("isClimbing", true);
            FindObjectOfType<AudioManager>().Play("Climb");
        }
        else
        {
            rb.gravityScale = 8f;
            anim.SetBool("isClimbing", false);

        }


    }



    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.02f, platformLayerMask);
        return raycastHit2d.collider != null;


    }




    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;


    }

    void Jump()
    {
        if (IsGrounded())
        {
            extraJumps = extraJumpValue;
            anim.SetBool("isJumping", false);


        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {



            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
            FindObjectOfType<AudioManager>().Play("Jump");


            extraJumps--;

        }
        else if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && extraJumps == 0)
        {


            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
            FindObjectOfType<AudioManager>().Play("Jump");
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
        if (collision.CompareTag("Death"))
        {
            FindObjectOfType<AudioManager>().Play("Death");
            anim.Play("Death");
            DeathFX.Play();
            FindObjectOfType<GameManager>().LoadNextLevel();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
        

    }

   
}

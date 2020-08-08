using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //FSM Alvin Roe - Platformer tutorial 15: Finite state machine

    //FSM
    private enum State {idle, running, switching, landing}
    private State state = State.idle;
    
    private Rigidbody2D rb;
    public Animator animator; //Calling the animator
    
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    
    private float moveInput;
    public float speed;
    public float checkRadius;
    
    public bool facingRight = true;
    private bool top;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //Creating groundchecker

        //PLAYER MOVEMENT
        moveInput = Input.GetAxis("Horizontal");

        if (knockbackCount <= 0)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            if (knockFromRight)
            {
                rb.velocity = new Vector2(-knockback, knockback);
            }
            else
            {
                rb.velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }

        //FLIP IMAGE
        if (facingRight == false && moveInput > 0) //facing left while moving right, solution
        {
            Flip();
        } else if(facingRight == true && moveInput < 0) { //facing right while moving left, solution
            Flip();
        }

        //SWITCH GRAVITY: UpArrow
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) 
        {
            GravitySwitching();
            state = State.switching;
        }

        StateSwitch(); //Checking the state
        animator.SetInteger("state", (int)state);
    }

    //Mirror sprite when running left
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    //Rotating player body when changing gravity
    void GravitySwitching()
    {
        rb.gravityScale *= -1;

        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        facingRight = !facingRight;

        if (isGrounded == true)
        {
            top = !top;
        }
    }

    private void StateSwitch()
    {
        if(state == State.switching)
        {
            //Jumping
            if(!isGrounded && !Input.GetKeyDown(KeyCode.UpArrow))
            {
                state = State.landing;
            }

        }
        else if(state == State.landing)
        {
            //landing
            if(isGrounded)
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            //Moving
            state = State.running;
        }
        else
        {
            //Idle
            state = State.idle;
        }
      
    }
}






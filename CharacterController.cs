using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float jumpForce;

    public float runSpeed = 10f;

    bool faceRight = true;

    float horizontalMove = 0f;

    Rigidbody2D rb;
    Vector2 moveVelocity;

    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
 
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate() {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * runSpeed, rb.velocity.y);
        //Vector2 horizontalMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //moveVelocity = horizontalMove.normalized * runSpeed;
        if(faceRight == false && horizontalMove > 0)
        {
            Flip();
        }
        else if(faceRight == true && horizontalMove < 0)
        {
            Flip();
        }
   
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    

    void Move()
    {
        
    }

    // private void FixedUpdate()
    //{
    //.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    //}


}

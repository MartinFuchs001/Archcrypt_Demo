using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float jumpHeight = 5;

    public const string RIGHT = "right";
    public const string LEFT = "left";
    string buttonPressed;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Animator anim;
    private Vector3 playerRotation;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       playerRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            buttonPressed = RIGHT;
            anim.SetBool("isRunning", true);
            //transform.eulerAngles = playerRotation;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            buttonPressed = LEFT;
            anim.SetBool("isRunning", true);
           // transform.eulerAngles = playerRotation - new Vector3(0, 180, 0);
        }
        else
        {
            buttonPressed = null;
            anim.SetBool("isRunning", false);
        } 
      
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        if(buttonPressed == RIGHT)
        {
            transform.eulerAngles = playerRotation;
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
        }
        else if(buttonPressed == LEFT)
        {
            transform.eulerAngles = playerRotation - new Vector3(0, 180, 0);
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            anim.SetBool("isJumping", false);
            isGrounded = true;
        }
    }
}

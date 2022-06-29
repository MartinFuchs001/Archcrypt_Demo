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

    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            buttonPressed = RIGHT;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            buttonPressed = LEFT;
        }
        else
        {
            buttonPressed = null;
        } 
      
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        if(buttonPressed == RIGHT)
        {
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
        }
        else if(buttonPressed == LEFT)
        {
            transform.position -= transform.right * (Time.deltaTime * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}

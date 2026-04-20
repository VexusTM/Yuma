using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 1f;
    public float JumpForce = 1f;
    private float horizontal;
    private bool isFacingRight = false;
    private bool noFlip = false;
    private bool isMoving = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;
    [SerializeField] public bool isGrounded;
    [SerializeField] private Rigidbody2D rb;
    private bool isCrouching = false;

    private void Start()
    {
        noFlip = false;
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", speed);
        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        {
            anim.SetBool("isGrounded", true);
            isGrounded = true;
        }
        else
        {
            anim.SetBool("isGrounded", false);
            isGrounded = false;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        //Crouching and shifting

        if (Input.GetKey(KeyCode.LeftControl)) //crouch
        {
            speed = 2;
            anim.SetBool("isCrouching", true);
            isCrouching = true;
        }
        else
        {
            anim.SetBool("isCrouching", false);
            isCrouching = false;
        }
        if (Input.GetKey(KeyCode.LeftShift)) //sprint
        {
            speed = 10;
            anim.SetBool("isCrouching", false);
        }
        else
        {
            speed = 5;
        }
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
        float yVelocity = rb.linearVelocity.y;
        float roundedVelocityY = Mathf.Round(yVelocity * 1f) / 1f;
        anim.SetFloat("yVelocity", roundedVelocityY);
        float xVelocity = rb.linearVelocity.x;
        float roundedVelocityX = Mathf.Round(xVelocity * 1f) / 1f;
        anim.SetFloat("xVelocity", roundedVelocityX);
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        //running
        if (roundedVelocityX > 0.1f || roundedVelocityX < -0.1f)
        {
            anim.SetBool("isRunning", true);
            //isRunning = true;
        }
        else if (!isMoving)
        {
            anim.SetBool("isRunning", false);
            //isRunning = false;
        }

        Flip();
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            if (!noFlip && !isMoving)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hide"))
        {
            if (isCrouching)
            {
                Debug.Log("is hidden");
            }
            
        }
    }

}

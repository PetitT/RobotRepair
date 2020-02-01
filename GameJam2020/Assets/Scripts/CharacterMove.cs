using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [Header("Movement")]
    public float baseMoveSpeed;
    public Transform maxXmaxY, minXminY;

    [Header("Jump")]
    public float baseJumpForce;
    public float gravity;
    public Transform groundCheck;
    public LayerMask ground;
    public float distanceFromGround;
    public Rigidbody2D rb;

    [Header("JumpIncrease")]
    public float jumpIncTimer;
    public float jumpIncForce;

    private bool isIncreasingJump = false;
    private float currentJumpIncTimer;
    private float currentJumpForce;
    private float currentGravityForce;
    private bool isJumping = true;
    private bool isGrounded = true;

    private void Start()
    {
        currentJumpIncTimer = jumpIncTimer;
    }

    private void Update()
    {
        Move();
        CheckGround();
        ClampPos();
    }

    private void FixedUpdate()
    {
        Jump();
        IncreaseJump();
    }

    private void Move()
    {
        float X = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(Vector2.right * X * baseMoveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                currentJumpIncTimer = jumpIncTimer;
                rb.velocity = Vector2.up * baseJumpForce;
            }
        }
    }

    private void IncreaseJump()
    {
        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
            if(currentJumpIncTimer > 0)
            {
                rb.velocity = Vector2.up * baseJumpForce;
                currentJumpIncTimer -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, distanceFromGround, ground);
    }

    private void ClampPos()
    {
        float X = transform.position.x;
        float Y = transform.position.y;

        if (X > maxXmaxY.position.x)
            X = maxXmaxY.position.x;
        if (X < minXminY.position.x)
            X = minXminY.position.x;

        if (Y < minXminY.position.y)
            Y = minXminY.position.y;
        if (Y > maxXmaxY.position.y)
            Y = maxXmaxY.position.y;

        transform.position = new Vector2(X, Y);
    }
}

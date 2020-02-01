using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
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

    [Header("JumpIncrease")]
    public float jumpIncTimer;
    public float jumpIncForce;
    private bool isIncreasingJump = false;


    private float currentJumpIncTimer;
    private float currentMoveSpeed;
    private float YMove;
    private bool isJumping = true;
    private bool isGrounded = true;

    private void Start()
    {
        currentMoveSpeed = baseMoveSpeed;
        currentJumpIncTimer = jumpIncTimer;
    }

    void Update()
    {
        Move();
        Jump();
        IncreaseJump();
        CheckJumpButton();
        ApplyGravity();
        CheckGround();
        ClampPos();
    }


    private void Move()
    {
        float X = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(Vector2.right * X * currentMoveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (!isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                YMove = baseJumpForce;
                isJumping = true;
                isIncreasingJump = true;
            }
        }
    }

    private void IncreaseJump()
    {
        if (isIncreasingJump)
        {
            currentJumpIncTimer -= Time.deltaTime;
            YMove += jumpIncForce * Time.deltaTime;

            if (currentJumpIncTimer <= 0)
            {
                currentJumpIncTimer = jumpIncTimer;
                isIncreasingJump = false;
            }
        }
    }

    private void CheckJumpButton()
    {
        if (isIncreasingJump)
        {
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Jump"))
            {
                isIncreasingJump = false;
                currentJumpIncTimer = jumpIncTimer;
            }
        }
    }

    private void ApplyGravity()
    {
        if (!isGrounded)
        {
            YMove -= gravity * Time.deltaTime;
        }
        else if(!isJumping)
        {
            YMove = 0f;
        }
        gameObject.transform.Translate(Vector2.up * YMove * Time.deltaTime);
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

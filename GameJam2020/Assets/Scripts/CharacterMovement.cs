using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [Header("Controls")]
    public string horizontalAxis;
    public string jump;

    [Header("Animation")]
    public Animator anim;
    public SpriteRenderer sprite;

    public enum AnimState { idle, running, jumping, falling, landing }

    [Header("Movement")]
    public float baseMoveSpeed;
    public Transform maxXmaxY, minXminY;
    public LayerMask wall;
    public List<Transform> wallchecksRight;
    public List<Transform> wallchecksLeft;
    private List<Transform> currentWallChecks;
    public float wallDistance;

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
    private bool isJumping = false;
    private bool isGrounded = false;
    private bool isFalling = false;

    [SerializeField] private AudioClip walk;

    private AnimState currentState = AnimState.idle;

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
        ApplyGravity();
        CheckGround();
        ClampPos();
        CheckFall();
    }


    private void Move()
    {
        float X = Input.GetAxis(horizontalAxis);

        if (X == 0)
        {
            ChangeAnimState(AnimState.idle);
            currentWallChecks = null;
        }
        else
        {
            if (X > 0)
            {
                sprite.flipX = false;
                currentWallChecks = wallchecksRight;
            }
            else
            {
                sprite.flipX = true;
                currentWallChecks = wallchecksLeft;
            }
            ChangeAnimState(AnimState.running);
        }

        if (currentWallChecks != null)
        {
            foreach (var wallcheck in currentWallChecks)
            {
                if (Physics2D.Raycast(wallcheck.position, Vector2.right, wallDistance, wall))
                {
                    X = 0;
                }
            }
        }

        gameObject.transform.Translate(Vector2.right * X * currentMoveSpeed * Time.deltaTime);

    }

    private void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetButton(jump))
            {
                isGrounded = false;
                YMove = baseJumpForce;
                isJumping = true;
                isIncreasingJump = true;
                ChangeAnimState(AnimState.jumping);
            }
        }
    }

    private void IncreaseJump()
    {
        if (isIncreasingJump)
        {
            if (Input.GetButton(jump))
            {
                currentJumpIncTimer -= Time.deltaTime;
                YMove += jumpIncForce * Time.deltaTime;

                if (currentJumpIncTimer <= 0)
                {
                    currentJumpIncTimer = jumpIncTimer;
                    isIncreasingJump = false;
                }
            }

            if (Input.GetButtonUp(jump))
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
        else if (isGrounded)
        {
            YMove = 0f;
        }
        gameObject.transform.Translate(Vector2.up * YMove * Time.deltaTime);
    }

    private void CheckGround()
    {
        if (isFalling)
            isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, distanceFromGround, ground);

        if (isGrounded)
            ChangeAnimState(AnimState.landing);
    }

    private void CheckFall()
    {
        if (YMove <= 0)
        {
            isFalling = true;
        }
        else if (YMove > 0)
        {
            isFalling = false;
            // ChangeAnimState(AnimState.landing);
        }

        if (YMove < 0)
            ChangeAnimState(AnimState.falling);
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

    private void ChangeAnimState(AnimState newState)
    {
        if (newState != currentState)
        {
            currentState = newState;

            switch (currentState)
            {
                case AnimState.idle:
                    anim.SetBool("IsWalking", false);
                    break;
                case AnimState.running:
                    anim.SetBool("IsWalking", true);
                    break;
                case AnimState.jumping:
                    anim.SetTrigger("Jump");
                    anim.SetBool("IsGrounded", false);
                    break;
                case AnimState.falling:
                    anim.SetBool("IsFalling", true);
                    anim.SetBool("IsGrounded", false);
                    break;
                case AnimState.landing:
                    anim.SetBool("IsFalling", false);
                    anim.SetBool("IsGrounded", true);
                    break;
                default:
                    break;
            }
        }
    }

    public void WalkSound()
    {

        SoundManager.instance.PlaySound(walk);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 5;
    public bool facingRight = true;
    private float horizontalMove;
    public Animator animator;

    public int jumpPower = 200;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isCrouch;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public static bool death;
    public static bool growUp;
    public static bool isStarUp;
    public static bool isFlowerUp;
    private float countdown = 0.5f;
    private float starCount = 12f;

    public int jump = 25;
    public Transform fireSpawn;
    public GameObject fireBall;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        rb.velocity = new Vector2 (horizontalMove* speed, rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {

        if (horizontalMove < 0.0f && facingRight)
        {
            flipPlayer();
        }

        if (horizontalMove > 0.0f && !facingRight)
        {
            flipPlayer();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    void flipPlayer()
    {
        facingRight = !facingRight;
        Vector2 playerScale = gameObject.transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 5;
    public bool facingRight = true;
    private float horizontalMove;
    public Animator animator;

    public int jumpPower = 200;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    public static bool death;
    public static bool growUp;
    public static bool isStarUp;
    public static bool isFlowerUp;

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
        if(jumpTimeCounter > 0)
        {
            rb.velocity = Vector2.up*jumpPower;
        }
        if (death)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("void"))
        {
            SceneManager.LoadScene("SampleScene");
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
        rb.velocity = Vector2.up*jumpPower;
    }

}

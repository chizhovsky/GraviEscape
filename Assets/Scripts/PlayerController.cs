using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveInput;
    private bool facingRight= true;
    private bool isGrounded;
    private int extraJumps;
    private float targetVelocityX;
    private float currentVelocityX;
    private Rigidbody2D rb;

    public float speed = 5;
    public float jumpForce = 5;
    public float checkRadius = 0.1f;
    public int extraJumpsValue = 2;
    public float smoothTime = 0.1f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    /// <summary>
    /// Initializes the number of extra jumps and gets the Rigidbody2D component
    /// to handle the player's physics.
    /// </summary>
    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Checks if the player is grounded. Handles horizontal movement input and smoothly
    /// adjusts the velocity. Flips the player if they change movement direction.
    /// </summary>
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        moveInput = Input.GetAxis("Horizontal");
        targetVelocityX = moveInput * speed;
        float smoothVelocity = Mathf.SmoothDamp(rb.linearVelocity.x, targetVelocityX, ref currentVelocityX, smoothTime);
        rb.linearVelocity = new Vector2(smoothVelocity, rb.linearVelocity.y);

        if (facingRight == false && moveInput > 0)
        {
            FlipPlayer();
        } 
        else if (facingRight && moveInput < 0)
        {
            FlipPlayer();
        }
    }

    /// <summary>
    /// Resets the number of extra jumps if the player is grounded. Handles jumping,
    /// including extra jumps in the air and a regular jump on the ground.
    /// </summary>
    private void Update()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    /// <summary>
    /// Changes the direction the player is facing by inverting the scale on the X axis.
    /// </summary>
    void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}

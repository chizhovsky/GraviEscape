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
    /// Инициализирует количество дополнительных прыжков и получает компонент Rigidbody2D
    /// для управления физикой игрока.
    /// </summary>
    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Проверяет, находится ли игрок на земле. Обрабатывает ввод для движения по горизонтали и плавно изменяет 
    /// скорость. Разворачивает игрока, если он меняет направление движения.
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
    /// Сбрасывает количество дополнительных прыжков, если игрок на земле. Обрабатывает прыжки, включая дополнительные
    /// прыжки в воздухе и обычный прыжок на земле.
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
    /// Меняет направление, в котором смотрит игрок, инвертируя масштаб по оси X.
    /// </summary>
    void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}

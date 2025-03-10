using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController playerController;
    private bool isTop;

    /// <summary>
    /// Initializes the Rigidbody2D and PlayerController components.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    /// <summary>
    /// Checks for input to switch gravity and calls the Rotation method.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
            Rotation();
        }
    }

    /// <summary>
    /// Rotates the player and toggles the facingRight flag in PlayerController.
    /// </summary>
    private void Rotation()
    {
        if (isTop == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        playerController.facingRight = !playerController.facingRight;
        isTop = !isTop;
    }
}

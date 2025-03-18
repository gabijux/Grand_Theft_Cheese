using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public LayerMask groundLayer; // Change "wallLayer" to "groundLayer"

    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move the enemy left/right
        rb.linearVelocity = new Vector2(moveDirection.x * speed, rb.linearVelocity.y);

        // Check if there's a wall ahead (now checking for Ground layer)
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, moveDirection, 1f, groundLayer);
        Debug.DrawRay(transform.position, moveDirection * 1f, Color.red); // Debugging

        if (groundHit.collider != null)
        {
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        moveDirection *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        rb.linearVelocity = new Vector2(moveDirection.x * speed, rb.linearVelocity.y); // Restart movement
    }
}

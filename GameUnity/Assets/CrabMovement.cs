using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    public float speed = 2f;
    public float walkDistance = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveDirection = Vector2.right;
    private Vector2 startPosition;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    void Update()
    {
        MoveCrab();
    }

    void MoveCrab()
    {
        rb.linearVelocity = moveDirection * speed;

        float distanceFromStart = Vector2.Distance(transform.position, startPosition);

        if (distanceFromStart >= walkDistance)
        {
            // Flip direction
            movingRight = !movingRight;
            moveDirection = movingRight ? Vector2.right : Vector2.left;

            // Flip the sprite
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

            // Reset start position to current
            startPosition = transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.Damage(1);

            if (animator != null)
            {
                Debug.Log("Triggering Snap animation");
                animator.SetTrigger("Snap");
            }

        }
    }
}

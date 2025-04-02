using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public LayerMask groundLayer;
    private Animator animator;
    private bool isTurning = false;

    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * speed, rb.linearVelocity.y);

        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, moveDirection, 0.5f, groundLayer);
        Debug.DrawRay(transform.position, moveDirection * 1f, Color.red);

        if (groundHit.collider != null)
        {
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        animator.SetTrigger("Turn");
        moveDirection *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        rb.linearVelocity = new Vector2(moveDirection.x * speed, rb.linearVelocity.y); // Restart movement
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.Damage(1);
        }
    }

}
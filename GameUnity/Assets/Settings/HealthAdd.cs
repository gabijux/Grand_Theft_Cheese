using UnityEngine;

public class HealthAdd : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("cheese");
            collision.gameObject.GetComponent<PlayerMovement>().AddHealth();
            Destroy(gameObject);
        }
    }
}

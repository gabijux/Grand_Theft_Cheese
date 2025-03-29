using UnityEngine;

public class Cheese : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("cheese");
            collision.gameObject.GetComponent<PlayerMovement>().GainPoints(100);
            Destroy(gameObject);
        }
    }
}
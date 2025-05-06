using UnityEngine;

//jumppad
public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("JumpPad");

            float diff = collision.gameObject.transform.position.y - transform.position.y;
            if (diff > 0.5f && diff < 5f)
            {
                collision.gameObject.GetComponent<PlayerMovement>().JumpPad();
                Debug.Log("JumpPad hit");
            }
        }
    }
}
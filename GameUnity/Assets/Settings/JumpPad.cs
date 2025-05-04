using UnityEngine;

//jumppad
public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float diff = Vector3.Dot(collision.gameObject.transform.position, gameObject.transform.position);
            if (diff > 17.38 && diff < 22.62)
            {
                collision.gameObject.GetComponent<PlayerMovement>().JumpPad();
                Debug.Log("JumpPad");
            }
        }
    }
}

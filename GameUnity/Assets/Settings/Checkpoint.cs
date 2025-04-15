using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointCollection checkpointCollection;
    public int p = 99;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hello.");

            checkpointCollection.SetCheckpoint(p);
        }
    }

}

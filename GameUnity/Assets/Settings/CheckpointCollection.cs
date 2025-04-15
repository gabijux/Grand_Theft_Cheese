using UnityEngine;

public class CheckpointCollection : MonoBehaviour
{
    [SerializeField] public GameObject[] checkpoints = null;
    static int currentCheckpoint = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Assign();
        GameObject.FindGameObjectWithTag("Player").transform.position = 
            checkpoints[currentCheckpoint].transform.position;
    }

    private void Assign()
    {
        for(int i=0; i< checkpoints.Length; i++)
        {
            checkpoints[i].GetComponent<Checkpoint>().p = i;
            checkpoints[i].GetComponent<Checkpoint>().checkpointCollection = this;
        }
    }

    public void SetCheckpoint(int p)
    {
        if (p > currentCheckpoint)
        {
            currentCheckpoint = p;
        }
    }

    public void ResetCheckpoint()
    {
        currentCheckpoint = 0;
    }
}

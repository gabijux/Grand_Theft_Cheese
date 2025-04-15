using UnityEngine;

public class playerpush : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float distance = 1f;
    public LayerMask boxmask;
    GameObject box;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxmask);
        

    }
   
}

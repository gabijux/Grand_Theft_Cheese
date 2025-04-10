using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public float speed; //platform speed
    public int startingPoint; //starting index
    public Transform[] points; // an arrey of tranform points
    private int i; // index of array
    public Transform posA, posB;
    Vector3 targetPos;
    
    void Start()
    {
        targetPos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        //checking the distance of the pltform and the point
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.position;
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.position;
        }
        //Moving the platform
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}

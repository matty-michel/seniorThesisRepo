using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private float repeatWidth;
    [SerializeField] float speed;
    
    void Start()
    {
        startPos = transform.position;
        //sets repeatWidth to half the length of the background
        repeatWidth = (GetComponent<BoxCollider2D>().size.x);
    }
    
    void Update()
    {
        //moves background to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
        //sets position of background back to start position when the halfway point is reached
        if (transform.position.x < (startPos.x - repeatWidth))
        {
            transform.position = startPos;
        }
    }
}
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [SerializeField] public float speed = 1f;
    
    private bool _movingLeft;
    
    // Update is called once per frame
    void Update()
    {
        //move to the left as long as enemy pos is >= leftEdge
        if (_movingLeft)
        {
            if (transform.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);   
            }
            else
            {
                DirectionChange();
            }
        }
        //move to the right as long as enemy pos is <= rightEdge
        else
        {
            if (transform.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
               DirectionChange(); 
            }
        }
    }

    //reverses value of _movingLeft to change direction
    private void DirectionChange()
    {
        _movingLeft =  !_movingLeft;
    }
    
    public void MoveInDirection(float direction)
    {
        //flipping enemy right
        if (direction > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //flipping enemy left
        else if (direction < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        //enemy moves in this direction
        transform.position = new Vector3(transform.position.x + Time.deltaTime * direction * speed, transform.position.y, transform.position.z);
    }
}

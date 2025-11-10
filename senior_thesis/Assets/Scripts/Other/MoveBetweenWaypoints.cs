using UnityEngine;

public class MoveBetweenWaypoints : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [SerializeField] private float speed = 1f;
    
    private bool _movingLeft;
    
    void Update()
    {
        //move to the left as long as platform pos is >= leftEdge
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
        //move to the right as long as platform pos is <= rightEdge
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
    
    private void MoveInDirection(float direction)
    {
        //platform moves in this direction
        transform.position = new Vector3(transform.position.x + Time.deltaTime * direction * speed, transform.position.y, transform.position.z);
    }
}

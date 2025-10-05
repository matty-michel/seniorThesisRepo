using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [SerializeField] private float speed = 1f;
    
    private Vector3 _initScale;
    private bool _movingLeft;

    void Awake()
    {
        //storing scale of enemy
        _initScale = transform.localScale;
    }
    
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
    
    private void MoveInDirection(int direction)
    {
        //enemy faces this direction--x can be negative or positive
        //transform.localScale = new Vector3(Mathf.Abs(_initScale.x) * direction, _initScale.y, _initScale.z);
        
        //enemy moves in this direction
        transform.position = new Vector3(transform.position.x + Time.deltaTime * direction * speed, transform.position.y, transform.position.z);
    }
}

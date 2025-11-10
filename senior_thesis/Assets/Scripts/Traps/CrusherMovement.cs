using UnityEngine;

public class CrusherMovement : MonoBehaviour
{
    [SerializeField] GameObject upperEdge;
    [SerializeField] GameObject lowerEdge;

    [SerializeField] private float speed;
    
    private bool _movingDown;
    
    void Update()
    {
        if (_movingDown)
        {
            if (transform.position.y >= lowerEdge.transform.position.y)
            {
                Move(-1);
            }
            else
            {
                ChangeDirection();
            }
        }
        else
        {
            if (transform.position.y <= upperEdge.transform.position.y)
            {
                Move(1);
            }
            else
            {
                ChangeDirection();
            }
        }
    }

    void Move(int direction)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed * direction, transform.position.z);
    }

    void ChangeDirection()
    {
        _movingDown = !_movingDown;
    }
}

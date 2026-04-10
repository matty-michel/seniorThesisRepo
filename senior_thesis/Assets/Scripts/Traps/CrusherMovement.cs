using UnityEngine;

public class CrusherMovement : MonoBehaviour
{
    [SerializeField] GameObject upperEdge;
    [SerializeField] GameObject lowerEdge;
    [SerializeField] private float speed;
    
    private PlayerController _playerController;
    private Health _playerHealth;
    private bool _movingDown;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }
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
        //change movement direction
        _movingDown = !_movingDown;
        
        //play hit animation
        _animator.SetBool("Hit", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player") && _playerController.isOnGround)
        {
            //killing player
            _playerHealth._dead = true; 
        }
        /*else if (collision.gameObject.CompareTag("Ground"))
        {
            //play animation
            _animator.SetBool("Hit", true);
        }*/
    }

    /*void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //play animation
            _animator.SetBool("Hit", false);
        }
    }*/
}

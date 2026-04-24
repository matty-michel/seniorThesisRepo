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
        _animator.SetTrigger("Hit");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player") && _playerController.isOnGround)
        {
            //killing player
            _playerHealth.currentHealth = 0; 
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            //killing enemy
            collision.gameObject.GetComponent<Health>().currentHealth = 0;
        }
    }
}

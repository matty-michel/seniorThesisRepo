using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Collider2D chaseRange;
    [SerializeField] private GameObject chaseIndicator;
    private EnemyPatrol _enemyPatrol;
    private Rigidbody2D _enemyRigidbody;
    private SpriteRenderer _spriteRenderer;
    private bool _playerInRange;
    private GameObject _player;
    
    void Awake()
    {
        //getting player
        _player = GameObject.FindGameObjectWithTag("Player");
        //getting enemy patrol script
        _enemyPatrol = GetComponentInParent<EnemyPatrol>();
        //getting rigidbody
        _enemyRigidbody = GetComponentInParent<Rigidbody2D>();
        //getting sprite renderer
        _spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (_playerInRange)
        {
            float moveDirection = _player.transform.position.x - transform.position.x;
            //Vector2 moveDirection = ((_player.transform.position - transform.position) * _enemyPatrol.speed).normalized;
            MoveTowardsPlayer(moveDirection);
            //move towards player
            //float moveDirection = _player.transform.position.x - transform.position.x;
            //_enemyPatrol.MoveInDirection(moveDirection);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            _playerInRange = true;
            
            //disabling enemy patrol
            _enemyPatrol.enabled = false;
            
            //activating chase indicator
            chaseIndicator.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player out of range");
            _playerInRange = false;
            
            //enabling enemy patrol
            _enemyPatrol.enabled = true;
            
            //deactivating chase indicator
            chaseIndicator.SetActive(false);
        }
    }

    void MoveTowardsPlayer(float direction)
    {
        if (direction < -0.01)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction > 0.01)
        {
            _spriteRenderer.flipX = false;
        }
        
        _enemyRigidbody.AddForce((transform.position * direction * _enemyPatrol.speed * Time.deltaTime).normalized);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange.bounds.extents.y);
    }
}

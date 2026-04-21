using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Collider2D chaseRange;
    private GameObject _player;
    private EnemyPatrol _enemyPatrol;
    private bool _playerInRange;
    
    void Awake()
    {
        //getting player
        _player = GameObject.FindGameObjectWithTag("Player");
        //getting enemy patrol script
        _enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    
    void Update()
    {
        if (_playerInRange)
        {
            //Vector2 moveDirection = (player.transform.position - transform.position).normalized;
            float moveDirection = _player.transform.position.x - transform.position.x;
            _enemyPatrol.MoveInDirection(moveDirection);
            //MoveTowardsPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            _playerInRange = true;
            //_enemyPatrol.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player out of range");
            _playerInRange = false;
            //_enemyPatrol.enabled = true;
        }
    }
        
    /*void MoveTowardsPlayer()
    {
        //getting the force direction by subtracting enemy pos from player pos
        //normalized keeps the force the same regardless of distance
        Vector2 moveDirection = (player.transform.position - transform.position).normalized;
        _enemyRigidbody.AddForce(moveDirection * speed);
    }*/

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange.bounds.extents.y);
    }
}

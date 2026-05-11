using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Collider2D chaseRange;
    [SerializeField] private GameObject chaseIndicator;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    
    private EnemyPatrol _enemyPatrol;
    
    private bool _playerInRange;
    
    void Awake()
    {
        //getting enemy patrol script
        _enemyPatrol = enemy.GetComponent<EnemyPatrol>();
    }
    
    void Update()
    {
        if (_playerInRange)
        {
            float moveDirection = Mathf.Sign(player.transform.position.x - enemy.transform.position.x);
            
            //move towards player
            _enemyPatrol.MoveInDirection(moveDirection);
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

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange.bounds.extents.y);
    }
}

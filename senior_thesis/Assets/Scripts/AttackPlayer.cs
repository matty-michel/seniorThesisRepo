using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    //enemy can attack immediately
    private float _cooldownTimer = Mathf.Infinity;
    private Rigidbody2D _enemyRigidbody;
    private Health _playerHealth;
    private GameObject _player;
    private bool _playerInRange;

    void Start()
    {
        //getting player
        _player = GameObject.Find("Player");
        //getting health component of player
        _playerHealth = _player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //updating cooldown
        _cooldownTimer += Time.deltaTime;
        
        if (_playerInRange)
        {
            if (_cooldownTimer >= attackCooldown)
            {
                //attack
                _cooldownTimer = 0;
                DamagePlayer();
            }
            //MoveTowardsPlayer();
        }
    }
    
    void DamagePlayer()
    {
        if (_playerInRange)
        {
            _playerHealth.TakeDamage(damage);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //player is in aggro range of enemy
        if (collision.CompareTag("Player"))
        {
            _playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }
}

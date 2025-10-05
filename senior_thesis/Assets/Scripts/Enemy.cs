using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    //enemy can attack immediately
    private float _cooldownTimer = Mathf.Infinity;
    private Health _playerHealth;
    private GameObject _player;
    private bool _playerInRange;
    private EnemyPatrol _enemyPatrol;
    
    //private Rigidbody2D _enemyRigidbody;
    //public float speed = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //getting player
        _player = GameObject.Find("Player");
        //getting health script of player
        _playerHealth = _player.GetComponent<Health>();
        //getting enemy patrol script of parent patrol object
        _enemyPatrol = GetComponentInParent<EnemyPatrol>();
        //getting enemy rigidbody
        //_enemyRigidbody = GetComponent<Rigidbody2D>();
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
        }

        //enemy only patrols when not attacking the player
        if (_enemyPatrol != null)
        {
            _enemyPatrol.enabled = !_playerInRange;
        }
    }
    
    void DamagePlayer()
    {
        //damage player when in range
        if (_playerInRange)
        {
            _playerHealth.TakeDamage(damage);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //player is in attack range of enemy
        if (collision.CompareTag("Player"))
        {
            _playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //player is out of attack range of enemy
        if (collision.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }
    
    /*void MoveTowardsPlayer()
    {
        //getting the force direction by subtracting enemy pos from player pos
        //normalized keeps the force the same regardless of distance
        Vector2 moveDirection = (_player.transform.position - transform.position).normalized;
        _enemyRigidbody.AddForce(moveDirection * speed);
    }*/
}

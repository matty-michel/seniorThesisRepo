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
    private EnemyChase _enemyChase;
    private Block _block;
    private Stunned _stunned;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //getting player
        _player = GameObject.Find("Player");
        //getting health script of player
        _playerHealth = _player.GetComponent<Health>();
        //getting enemy patrol script of parent patrol object
        _enemyPatrol = GetComponentInParent<EnemyPatrol>();
        //getting block script from player
        _block = _player.GetComponent<Block>();
        //getting stunned script
        _stunned = GetComponentInParent<Stunned>();
    }

    // Update is called once per frame
    void Update()
    {
        //enemy does not try to attack player when the player is dead
        if (_playerHealth.currentHealth <= 0)
        {
            _playerInRange = false;
        }
        
        //updating cooldown
        _cooldownTimer += Time.deltaTime;
        
        if (_playerInRange)
        {
            if (_cooldownTimer >= attackCooldown && !_block.isBlocking)
            {
                //attack
                _cooldownTimer = 0;
                DamagePlayer();
            }
            else if (_cooldownTimer >= attackCooldown && _block.isBlocking)
            {
                //enemy is stunned
                _cooldownTimer = 0;
                _stunned.StartStunCoroutine();
            }
        }

        //enemy only chases when not attacking the player
        if (_enemyChase != null)
        {
            _enemyChase.enabled = !_playerInRange;
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
}

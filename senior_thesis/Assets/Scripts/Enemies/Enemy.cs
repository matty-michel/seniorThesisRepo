using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private EnemyChase enemyChase;
    
    //enemy can attack immediately
    private float _cooldownTimer = Mathf.Infinity;
    
    private Health _playerHealth;
    private GameObject _player;
    private bool _playerInRange;
    private Block _block;
    
    private Stunned _stunned;
    
    void Awake()
    {
        //getting player
        _player = GameObject.FindGameObjectWithTag("Player");
        
        //getting health & block script of player
        _playerHealth = _player.GetComponent<Health>();
        _block = _player.GetComponent<Block>();
        
        //getting stunned script from enemy
        _stunned = GetComponentInParent<Stunned>();
    }
    
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
        if (enemyChase != null)
        {
            enemyChase.enabled = !_playerInRange;
        }
    }
    
    void DamagePlayer()
    {
        //damage player when in ranges
        if (_playerInRange)
        {
            _playerHealth.PlayerTakeDamage(damage);
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

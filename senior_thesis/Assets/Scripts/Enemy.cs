using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    //enemy can attack immediately
    private float _cooldownTimer = Mathf.Infinity;
    private Health _playerHealth;
    private Rigidbody2D _enemyRigidbody;
    private GameObject _player;
    private bool _playerInRange;
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //getting rigidbody
        _enemyRigidbody =  GetComponent<Rigidbody2D>();
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

    /*void MoveTowardsPlayer()
    {
        //getting the force direction by subtracting enemy pos from player pos
        //normalized keeps the force the same regardless of distance
        Vector2 moveDirection = (_player.transform.position - transform.position).normalized;
        _enemyRigidbody.AddForce(moveDirection * speed);
    }*/

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

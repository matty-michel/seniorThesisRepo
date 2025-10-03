using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _enemyRigidbody;
    private GameObject _player;
    private bool _playerInRange;
    //private float _detectionRange = 5f;
    //private float _attackRange = 1f;
    //private bool aggro = false;
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //getting rigidbody
        _enemyRigidbody =  GetComponent<Rigidbody2D>();
        //getting player
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInRange)
        {
            MoveTowardsPlayer();
        }
        /*if (InDetectionRange())
        {
            aggro = true;
            MoveTowardsPlayer();
        }*/
    }

    void MoveTowardsPlayer()
    {
        //getting the force direction by subtracting enemy pos from player pos
        //normalized keeps the force the same regardless of distance
        Vector2 moveDirection = (_player.transform.position - transform.position).normalized;
        _enemyRigidbody.AddForce(moveDirection * speed);
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

    /*bool InDetectionRange()
    {
        float playerDistanceSqr = (_player.transform.position - transform.position).sqrMagnitude;
        //returns true when player is within detection range
        return playerDistanceSqr <= (_detectionRange * _detectionRange);
    }*/
}

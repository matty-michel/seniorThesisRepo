using System;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] private float yRange;
    private GameObject _player;
    private Health _playerHealth;
    private Block _block;

    private void Awake()
    {
        //getting reference to player
        _player = GameObject.Find("Player");
        //getting player's health & block scripts
        _playerHealth = _player.GetComponent<Health>();
        _block = _player.GetComponent<Block>();
    }

    private void Update()
    {
        //destroying projectiles if they hit the ground
        if (transform.position.y <= yRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //destroying the projectile & damaging the player when it collides with player
        if (other.CompareTag("Player"))
        {
            if (!_block.isBlocking)
            {
                Destroy(gameObject);
                _playerHealth.TakeDamage(1);  
            }
            //player is immune to damage from projectiles
            else if (_block.isBlocking)
            {
                Destroy(gameObject);
                Debug.Log("Projectile blocked");
            }
        }
    }
}

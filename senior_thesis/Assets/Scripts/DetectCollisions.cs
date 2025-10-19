using System;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] private float yRange;
    private GameObject _player;
    private Health _playerHealth;

    private void Awake()
    {
        //getting player's health
        _player = GameObject.Find("Player");
        _playerHealth = _player.GetComponent<Health>();
    }

    private void Update()
    {
        //destroying projectiles if they fall past the ground
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
            Destroy(gameObject);
            _playerHealth.TakeDamage(1);
        }
    }
}

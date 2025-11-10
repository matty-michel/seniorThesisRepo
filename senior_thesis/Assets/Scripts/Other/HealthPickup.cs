using System;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] Collider2D playerCollider;
    [SerializeField] private int healthAmount;
    
    private Health _playerHealth;

    void Awake()
    {
        _playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == playerCollider)
        {
            Debug.Log("added " + healthAmount);
            Destroy(gameObject);
            _playerHealth.currentHealth += healthAmount;
        }
    }
}

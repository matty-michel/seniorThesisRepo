using System;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healthAmount;
    [SerializeField] private AudioClip gotPickupSound;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject healthBarObj;
    
    private Collider2D _playerCollider;
    private Health _playerHealth;
    private Animator _animator;
    private HealthBar _healthBar;

    void Awake()
    {
        _playerHealth = player.GetComponent<Health>();
        _playerCollider = player.GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        _healthBar = healthBarObj.GetComponent<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == _playerCollider)
        {
            //set animator parameter
            _animator.SetBool("Collected", true);
            //play got pickup sound
            SoundManager.Instance.PlayAudio(gotPickupSound);
            //destroy pickup
            Destroy(gameObject, 0.5f);
            //add to player's health
            _playerHealth.currentHealth = Mathf.Clamp(_playerHealth.currentHealth + healthAmount, 0, _playerHealth.maxHealth);
            //update health bar
            _healthBar.SetHealth(_playerHealth.currentHealth);
        }
    }
}

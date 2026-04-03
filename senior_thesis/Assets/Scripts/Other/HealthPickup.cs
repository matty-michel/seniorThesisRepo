using System;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healthAmount;
    [SerializeField] private AudioClip gotPickupSound;
    private Collider2D _playerCollider;
    private Animator _animator;
    private Health _playerHealth;

    void Awake()
    {
        _playerHealth = GameObject.Find("Player").GetComponent<Health>();
        _playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
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
            _playerHealth.currentHealth += healthAmount;
        }
    }
}

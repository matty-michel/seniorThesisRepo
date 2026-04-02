using System;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] Collider2D playerCollider;
    [SerializeField] private int healthAmount;
    [SerializeField] private AudioClip gotPickupSound;
    private Animator _animator;
    private Health _playerHealth;

    void Awake()
    {
        _playerHealth = GameObject.Find("Player").GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == playerCollider)
        {
            //set animator parameter
            _animator.SetBool("Collected", true);
            //play got pickup sound
            SoundManager.Instance.PlayAudio(gotPickupSound);
            //destroy pickup
            gameObject.SetActive(false);
            //add to player's health
            _playerHealth.currentHealth += healthAmount;
        }
    }
}

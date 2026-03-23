using System;
using UnityEngine;

public class CrushPlayer : MonoBehaviour
{
    private float _countdown;
    private PlayerController _playerController;
    private Health _playerHealth;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerHealth = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //only crushing player when they are caught between the crusher & the ground
        if (collision.gameObject.CompareTag("Crusher") && _playerController.isOnGround)
        {
            //killing player
            _playerHealth.PlayerTakeDamage(_playerHealth.maxHealth);
        }
    }
}

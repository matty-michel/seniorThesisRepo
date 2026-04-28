using System;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    private PlayerController _playerController;
    private Health _playerHealth;

    void Start()
    {
        //getting player controller & health
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && _playerController.isOnGround)
        {
            //killing player
            _playerHealth.currentHealth = 0;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            //killing enemy
            other.gameObject.GetComponent<Health>().currentHealth = 0;
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _playerController.isOnGround)
        {
            //killing player
            _playerHealth.currentHealth = 0;
        }
        else if (other.CompareTag("Enemy"))
        {
            //killing enemy
            other.GetComponent<Health>().currentHealth = 0;
        }
    }*/
}

using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{
    private Collider2D _playerCollider;
    private GameObject _player;
    private Health _playerHealth;
    private PlayerController _playerController;

    private GameObject _enemy;
    
    private float _originalSpeed;
    private float _originalJumpForce;

    private bool _playerOnSpikes;
    private bool _enemyOnSpikes;

    void Awake()
    {
        //getting player
        _player = GameObject.FindGameObjectWithTag("Player");
        //getting health & control scripts
        _playerHealth = _player.GetComponent<Health>();
        _playerController = _player.GetComponent<PlayerController>();
        _playerCollider = _player.GetComponent<Collider2D>();
        //setting original speed & jump force to reset in collision exit
        _originalSpeed = _playerController.speed;
        _originalJumpForce = _playerController.jumpForce;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == _playerCollider)
        {
            _playerOnSpikes = true;
            _playerController.speed *= 0.5f;
            //_playerController.jumpForce *= 0.5f;
            StartCoroutine("DamagePlayer");
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            _enemy = other.gameObject;
            _enemy.GetComponent<Health>().currentHealth = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == _playerCollider)
        {
            _playerOnSpikes = false;
            _playerController.speed = _originalSpeed;
            _playerController.jumpForce = _originalJumpForce; 
        }
    }

    IEnumerator DamagePlayer()
    {
        while (_playerOnSpikes)
        {
            _playerHealth.PlayerTakeDamage(1);
        
            yield return new WaitForSeconds(1.5f);
        }
    }
}

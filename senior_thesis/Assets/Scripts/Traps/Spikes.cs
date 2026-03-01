using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{
    //[SerializeField] Collider2D playerCollider;
    //private GameObject _player;
    private Health _playerHealth;
    private PlayerController _playerController;
    
    private float _originalSpeed;
    private float _originalJumpForce;

    private bool _playerOnSpikes;

    void Awake()
    {
        //getting health & control scripts
        _playerHealth = GetComponent<Health>();
        _playerController = GetComponent<PlayerController>();
        //setting original speed & jump force to reset in collision exit
        _originalSpeed = _playerController.speed;
        _originalJumpForce = _playerController.jumpForce;
        Debug.Log(_originalSpeed);
        Debug.Log(_originalJumpForce);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            _playerOnSpikes = true;
            _playerController.speed *= 0.5f;
            _playerController.jumpForce *= 0.5f;
            StartCoroutine("DamagePlayer");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            _playerOnSpikes = false;
            _playerController.speed = _originalSpeed;
            _playerController.jumpForce = _originalJumpForce; 
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        //player takes damage & is slowed down when they hit spikes
        if (collision.collider == playerCollider)
        {
            _playerOnSpikes = true;
            _playerController.speed *= 0.5f;
            _playerController.jumpForce *= 0.5f;
            StartCoroutine("DamagePlayer");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //player speed & jump force are reset when they are no longer hitting spikes
        if (collision.collider == playerCollider)
        {
            _playerOnSpikes = false;
            _playerController.speed = _originalSpeed;
            _playerController.jumpForce = _originalJumpForce;
        }
    }*/

    IEnumerator DamagePlayer()
    {
        while (_playerOnSpikes)
        {
            _playerHealth.TakeDamage(1);
        
            yield return new WaitForSeconds(1.5f);
        }
    }
}

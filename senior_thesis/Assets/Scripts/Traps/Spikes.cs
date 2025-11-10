using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] Collider2D playerCollider;
    private GameObject _player;
    private Health _playerHealth;
    private PlayerController _playerController;
    
    private float _originalSpeed;
    private float _originalJumpForce;
    
    //private float _cooldownTimer = Mathf.Infinity;

    void Awake()
    {
        //getting player object
        _player = GameObject.FindGameObjectWithTag("Player");
        //getting health & control scripts
        _playerHealth = _player.GetComponent<Health>();
        _playerController = _player.GetComponent<PlayerController>();
        //setting original speed & jump force to reset in collision exit
        _originalSpeed = _playerController.speed;
        _originalJumpForce = _playerController.jumpForce;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //player takes damage & is slowed down when they hit spikes
        if (collision.collider == playerCollider)
        {
            _playerHealth.TakeDamage(1);
            _playerController.speed *= 0.5f;
            _playerController.jumpForce *= 0.5f;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //player speed & jump force are reset when they are no longer hitting spikes
        if (collision.collider == playerCollider)
        {
            _playerController.speed = _originalSpeed;
            _playerController.jumpForce = _originalJumpForce;
        }
    }
}

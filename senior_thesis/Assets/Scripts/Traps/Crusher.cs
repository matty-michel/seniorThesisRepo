using UnityEngine;

public class Crusher : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private PlayerController _playerController;
    private Health _playerHealth;
    
    private Animator _animator;

    void Start()
    {
        //getting player controller & health
        _playerController = player.GetComponent<PlayerController>();
        _playerHealth = player.GetComponent<Health>();

        //getting crusher's animator
        _animator = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && _playerController.isOnGround)
        {
            //killing player
            _playerHealth.currentHealth = 0;
            
            //playing hit animation
            _animator.SetTrigger("Hit");
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            //killing enemy
            other.gameObject.GetComponent<Health>().currentHealth = 0;
            
            //playing hit animation
            _animator.SetTrigger("Hit");
        }
    }
}

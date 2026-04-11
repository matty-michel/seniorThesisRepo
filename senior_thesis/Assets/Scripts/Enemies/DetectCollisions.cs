using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private GameObject _player;
    private Health _playerHealth;
    private Block _block;
    
    private Animator _animator;

    private void Awake()
    {
        //getting reference to player
        _player = GameObject.Find("Player");
        //getting player's health & block scripts
        _playerHealth = _player.GetComponent<Health>();
        _block = _player.GetComponent<Block>();
        //getting animator from childed object with sprite renderer
        _animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //destroying the projectile & damaging the player when it collides with player
        if (other.CompareTag("Player"))
        {
            //playing fireball explosion animation
            _animator.SetTrigger("Hit");
            //setting speed to 0 so projectile stops moving
            speed = 0;
            
            if (!_block.isBlocking)
            {
                Destroy(gameObject, 0.5f);
                _playerHealth.PlayerTakeDamage(1);  
            }
            //player is immune to damage from projectiles
            else if (_block.isBlocking)
            {
                Destroy(gameObject, 0.5f);
                Debug.Log("Projectile blocked");
            }
        }
        else if (other.CompareTag("Ground"))
        {
            //playing fireball explosion animation
            _animator.SetTrigger("Hit");
            //setting speed to 0 so projectile stops moving
            speed = 0;
            Destroy(gameObject, 0.5f);
        }
    }
}

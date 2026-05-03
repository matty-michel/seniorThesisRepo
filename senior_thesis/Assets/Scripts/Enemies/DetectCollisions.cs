using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private GameObject _player;
    private Health _playerHealth;
    private Block _block;
    
    private Animator _animator;
    private AudioSource _audio;

    private void Awake()
    {
        //getting reference to player
        _player = GameObject.Find("Player");
        if (_player != null)
        {
            //getting player's health & block scripts
            _playerHealth = _player.GetComponent<Health>();
            _block = _player.GetComponent<Block>();
        }

        //getting animator from childed object with sprite renderer
        _animator = GetComponentInChildren<Animator>();
        //getting audio source
        _audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        //moving projectile down
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
            //playing audio
            _audio.Play();
            
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
        //destroying projectile if it hits the ground
        else if (other.CompareTag("Ground") || other.CompareTag("MovingPlatform"))
        {
            //playing fireball explosion animation
            _animator.SetTrigger("Hit");
            //setting speed to 0 so projectile stops moving
            speed = 0;
            //playing audio
            _audio.Play();
            
            Destroy(gameObject, 0.5f);
        }
    }
}

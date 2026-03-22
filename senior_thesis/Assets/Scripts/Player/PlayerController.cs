using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    //private PlayerHealth health;
    
    private Rigidbody2D _playerRigidBody;
    private float _horizontalInput;
    
    public bool isOnGround = true;
    private bool _hasPowerup = false;
    private int _jumpCounter = 0;
    
    public float speed;
    public float jumpForce;
    
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        //health = GetComponent<PlayerHealth>();
    }
    
    void Update()
    {
        //only allows player to jump when they are on the ground
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                //applies upward force immediately
                _playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                //player is off the ground
                isOnGround = false;
                _jumpCounter++;
                Debug.Log("Jump count (on ground): " + _jumpCounter);
            }
            //only allowing double jump when the player has a powerup
            else if (_hasPowerup && _jumpCounter < 2)
            {
                //applies upward force immediately
                _playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                
                //do something that prevents jumping
                _jumpCounter++;
                Debug.Log("Jump count (w/ powerup): " + _jumpCounter);
            }
        }
        
        //character moves back and forth
        _horizontalInput = Input.GetAxis("Horizontal");
        //must use Vector3 for transform.Translate
        transform.Translate(Vector3.right * _horizontalInput * Time.deltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            _jumpCounter = 0;
        }
        else if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isOnGround = true;
            _jumpCounter = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Powerup"))
        {
            _hasPowerup = true;
            Debug.Log("Got powerup");
            
            //destroying powerup
            Destroy(collision.gameObject);
            
            //starts countdown routine
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        
        _hasPowerup = false;
        Debug.Log("Lost powerup");
    }
}

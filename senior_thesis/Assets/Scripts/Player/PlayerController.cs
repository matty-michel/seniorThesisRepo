using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip doubleJumpSound;
    [SerializeField] private AudioClip gotPowerupSound;
    //[SerializeField] private AudioClip lostPowerupSound;
    
    private Rigidbody2D _playerRigidBody;
    private float _horizontalInput;
    
    public bool isOnGround = true;
    private bool _hasPowerup;
    private int _jumpCounter;
    
    public float speed;
    public float jumpForce;
    
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
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
                //update jump counter
                _jumpCounter++;
                Debug.Log("Jump count (on ground): " + _jumpCounter);
                //play jump sound
                SoundManager.Instance.PlayAudio(jumpSound);
            }
            //only allowing double jump when the player has a powerup
            else if (_hasPowerup && _jumpCounter < 2)
            {
                //applies upward force immediately
                _playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                
                //update jump counter
                _jumpCounter++;
                Debug.Log("Jump count (w/ powerup): " + _jumpCounter);
                
                //play double jump sound
                SoundManager.Instance.PlayAudio(doubleJumpSound);
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
            
            //playing powerup sound
            SoundManager.Instance.PlayAudio(gotPowerupSound);
            
            //starts countdown routine
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        
        _hasPowerup = false;
        Debug.Log("Lost powerup");
        
        //playing lost powerup sound
    }
}

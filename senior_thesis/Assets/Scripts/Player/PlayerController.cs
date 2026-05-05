using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip doubleJumpSound;
    [SerializeField] private AudioClip gotPowerupSound;
    [SerializeField] private AudioClip lostPowerupSound;
    [SerializeField] private GameObject powerupIndicator;
    
    private Rigidbody2D _playerRigidBody;
    private Animator _playerAnimator;
    private float _horizontalInput;
    
    public bool isOnGround = true;
    private bool hasPowerup;
    private int _jumpCounter;
    
    public float speed;
    public float jumpForce;
    
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
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
                
                //play jump sound
                SoundManager.Instance.PlayAudio(jumpSound);
            }
            //only allowing double jump when the player has a powerup
            else if (hasPowerup && _jumpCounter < 2)
            {
                //setting jump animation to false
                _playerAnimator.SetBool("Grounded", false);
                
                //applies upward force immediately
                _playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                
                //update jump counter
                _jumpCounter++;
                
                //play double jump sound
                SoundManager.Instance.PlayAudio(doubleJumpSound);
                
                //playing double jump animation
                _playerAnimator.CrossFadeInFixedTime("Player_DoubleJump", 0.5f);
            }
        }

        //flipping player right
        if (_horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //flipping player left
        else if (_horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        //character moves back and forth
        _horizontalInput = Input.GetAxis("Horizontal");
        _playerRigidBody.linearVelocity = new Vector2(_horizontalInput * speed, _playerRigidBody.linearVelocity.y);
        
        //setting run animation
        _playerAnimator.SetBool("Running", _horizontalInput != 0);
        //setting jump animation
        _playerAnimator.SetBool("Grounded", isOnGround);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log(other.gameObject.name);
            hasPowerup = true;
            
            //activating powerup indicator
            powerupIndicator.SetActive(true);
            
            //setting animator parameter
            other.gameObject.GetComponent<Animator>().SetBool("Collected", true);
            
            //playing powerup sound
            SoundManager.Instance.PlayAudio(gotPowerupSound);
            
            //starts countdown routine from player controller
            StartCoroutine(PowerupCountdownRoutine());
            
            //destroying powerup
            Destroy(other.gameObject, 0.5f);
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        //powerup active for 10 seconds
        yield return new WaitForSeconds(10);
        
        hasPowerup = false;
        Debug.Log("Lost powerup");
        
        //deactivating powerup indicator
        powerupIndicator.SetActive(false);
        
        //playing lost powerup sound
        SoundManager.Instance.PlayAudio(lostPowerupSound);
    }
}

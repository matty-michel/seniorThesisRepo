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
    private bool hasPowerup;
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
                
                //play jump sound
                SoundManager.Instance.PlayAudio(jumpSound);
            }
            //only allowing double jump when the player has a powerup
            else if (hasPowerup && _jumpCounter < 2)
            {
                //applies upward force immediately
                _playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                
                //update jump counter
                _jumpCounter++;
                
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            
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

    public IEnumerator PowerupCountdownRoutine()
    {
        //powerup active for 10 seconds
        yield return new WaitForSeconds(10);
        
        hasPowerup = false;
        Debug.Log("Lost powerup");
        
        //playing lost powerup sound
    }
}

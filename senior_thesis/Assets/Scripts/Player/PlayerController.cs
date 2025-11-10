using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private float _horizontalInput;
    
    public bool isOnGround = true;
    private bool _hasPowerup;
    
    public float speed;
    public float jumpForce;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
            }
            //only allowing double jump when the player has a powerup
            else if (_hasPowerup)
            {
                //applies upward force immediately
                _playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
        }
        else if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isOnGround = true;
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

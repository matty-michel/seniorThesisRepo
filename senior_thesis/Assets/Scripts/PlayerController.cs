using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private float _horizontalInput;
    private bool _isOnGround = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            //applies upward force immediately
            _playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //player is off the ground
            _isOnGround = false;
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
            _isOnGround = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if enemy is within attack range & player presses E
        if (collision.gameObject.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.E))
        {
            //referencing the health script of the enemy
            collision.GetComponent<Health>().TakeDamage(1);
        }
    }
}

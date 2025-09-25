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
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            //applies upward force immediately
            _playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            //player is off the ground
            _isOnGround = false;
        }
        
        //character moves back and forth
        _horizontalInput = Input.GetAxis("Horizontal");
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
}

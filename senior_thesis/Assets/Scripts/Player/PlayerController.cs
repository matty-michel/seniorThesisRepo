using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private float _horizontalInput;
    public bool isOnGround = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //applies upward force immediately
            _playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //player is off the ground
            isOnGround = false;
        }
        //player is blocking -- cannot move or attack
        /*if(Input.GetKey(KeyCode.LeftShift) && _isOnGround)
        {
            //disable controller
            //disable health script?
        }*/
        
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
    }
}

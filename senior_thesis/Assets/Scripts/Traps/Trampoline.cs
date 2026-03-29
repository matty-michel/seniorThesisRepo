using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject player;
    private PlayerController _playerController;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _playerController = player.GetComponent<PlayerController>();
        _rigidbody = player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            //set on ground to false so player can't jump after bouncing
            _playerController.isOnGround = false;
            //add upward force to player
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}

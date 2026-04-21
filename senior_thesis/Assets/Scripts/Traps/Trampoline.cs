using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioClip jumpSound;
    private GameObject _player;
    private PlayerController _playerController;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _rigidbody = _player.GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            //set on ground to false so player can't jump after bouncing
            _playerController.isOnGround = false;
            //add upward force to player
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //setting animation parameter
            _animator.SetBool("Jump", true);
            //playing jump sound
            SoundManager.Instance.PlayAudio(jumpSound);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            //setting animation parameter
            _animator.SetBool("Jump", false);
        }
    }
}

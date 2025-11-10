using UnityEngine;

public class UpdatePlayerPos : MonoBehaviour
{
    private bool _isOnMovingPlatform;
    private GameObject _movingPlatform;
    private Rigidbody2D _playerRigidbody;

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (_isOnMovingPlatform)
        {
            _playerRigidbody.MovePosition(_movingPlatform.transform.position);
            //transform.position.x = _movingPlatform.transform.position;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            _movingPlatform = other.gameObject;
            _isOnMovingPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            _isOnMovingPlatform = false;
        }
    }
}

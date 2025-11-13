using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour
{
    private GameObject _player;
    private PlayerController _playerController;
    private Rigidbody2D _playerRigidbody;

    void Awake()
    {
        //getting player object, player controller script, & rigidbody
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerController.speed = 0.5f;
            _playerController.jumpForce = 0.5f;
            Debug.Log(_playerController.enabled);
            StartCoroutine(DrownPlayer());
        }
    }

    IEnumerator DrownPlayer()
    {
        yield return new WaitForSeconds(3f);
        
        Destroy(_player);
    }
}

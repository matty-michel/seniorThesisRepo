using System;
using UnityEngine;

public class CrushPlayer : MonoBehaviour
{
    [SerializeField] private float crushTimer;
    
    //private bool _playerInRange;
    private float _countdown;
    
    void Update()
    {
        /*if (_playerInRange)
        {
            _countdown += Time.deltaTime;
            
            if (_countdown >= crushTimer)
            {
                _countdown = 0;
            }
        }
        else
        {
            _countdown = 0;
        }*/
        
    }

    /*private void Slam(float direction)
    {
        Debug.Log("Slam");
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * downwardSpeed * direction, transform.position.z);
    }

    private void ChangeDirection()
    {
        _movingDown = !_movingDown;
    }*/

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = false;
        } 
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}

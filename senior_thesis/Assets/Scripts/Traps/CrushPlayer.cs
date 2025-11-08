using System;
using UnityEngine;

public class CrushPlayer : MonoBehaviour
{
    [SerializeField] GameObject upperEdge;
    [SerializeField] GameObject lowerEdge;
    
    [SerializeField] private float upwardSpeed;
    [SerializeField] private float downwardSpeed;

    [SerializeField] private float crushTimer;
    
    private bool _playerInRange;
    private float _countdown = 0f;
    private bool _movingDown;

    // Update is called once per frame
    void Update()
    {
        if (_playerInRange)
        {
            _countdown += Time.deltaTime;
            Debug.Log(_countdown);
            if (_countdown >= crushTimer)
            {
                Slam();
                _countdown = 0;
                //move back up
                Debug.Log(_countdown);
            }
        }
        else
        {
            _countdown = 0;
        }
        
    }

    private void Slam()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * downwardSpeed, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().currentHealth = 0;
        }
    }
}

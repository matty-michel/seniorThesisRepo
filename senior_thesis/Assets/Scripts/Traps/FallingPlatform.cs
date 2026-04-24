using System;
using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float timeBeforeFall;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //wait a few seconds before dropping platform
            StartCoroutine(Fall());
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        
        //platform falls
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.AddForce(Vector2.down * 2.5f, ForceMode2D.Impulse);
        
        //destroy platform
        Destroy(gameObject, timeBeforeFall);
    }
}

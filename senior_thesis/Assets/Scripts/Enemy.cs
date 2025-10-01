using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _enemyRigidbody;
    private GameObject _player;
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //getting rigidbody
        _enemyRigidbody =  GetComponent<Rigidbody2D>();
        //getting player
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveTowardsPlayer()
    {
        //getting the force direction by subtracting enemy pos from player pos
        //normalized keeps the force the same regardless of distance
        Vector2 moveDirection = (_player.transform.position - transform.position).normalized;
        _enemyRigidbody.AddForce(moveDirection * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
			MoveTowardsPlayer();
        }
    }
}

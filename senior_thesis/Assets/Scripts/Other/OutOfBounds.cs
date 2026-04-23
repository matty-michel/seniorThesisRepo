using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private Health _playerHealth;
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //killing player when they fall out of bounds
        if (other.CompareTag("Player"))
        {
            _playerHealth._dead = true;
        }
        //destroying enemies that fall out of bounds
        else if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        //destroying projectiles that fall out of bounds
        else if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }
}

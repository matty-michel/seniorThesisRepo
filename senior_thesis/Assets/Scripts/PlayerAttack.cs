using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //RaycastHit detects colliders within its range
    private RaycastHit2D[] _hits;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private Transform attackTransform;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private int damage = 1;
    [SerializeField] private float pushbackForce = 5f;
    
    private void Update()
    {
        //attacking when player presses "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
           Attack(); 
        }
    }

    private void Attack()
    {
        //filling _hits array with any enemies within range
        _hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, Vector2.right, 0f, attackableLayer);

        //for each enemy in attack range
        for (int i = 0; i < _hits.Length; i++)
        {
            //accessing each enemy's health
            Health enemyHealth = _hits[i].collider.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            
            Rigidbody2D enemyRigidbody = _hits[i].collider.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                Vector3 awayFromPlayer = enemyRigidbody.transform.position - transform.position;
                enemyRigidbody.AddForce(awayFromPlayer * pushbackForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        //creates a physical representation of the raycast in the scene
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}

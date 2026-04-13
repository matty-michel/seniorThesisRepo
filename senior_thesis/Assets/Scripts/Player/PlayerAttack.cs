using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private Transform attackTransform;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private int damage = 1;
    [SerializeField] private float pushbackForce = 5f;
    
    //RaycastHit detects colliders within its range
    private RaycastHit2D[] _hits;
    //cooldown timer for attack
    private float _cooldownTimer = Mathf.Infinity;
    
    private void Update()
    {
        _cooldownTimer += Time.deltaTime;
        
        //attacking when player presses "E" & cooldown is over
        if (Input.GetKeyDown(KeyCode.E) && _cooldownTimer >= attackCooldown)
        {
           Attack(); 
        }
    }

    private void Attack()
    {
        //resetting cooldown timer
        _cooldownTimer = 0;
        
        //filling _hits array with any enemies within range
        _hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, Vector2.right, 0f, attackableLayer);

        //for each enemy in attack range
        for (int i = 0; i < _hits.Length; i++)
        {
            //accessing each enemy's health
            Health enemyHealth = _hits[i].collider.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.EnemyTakeDamage(damage);
            }
            
            //accessing each enemy's rigidbody
            Rigidbody2D enemyRigidbody = _hits[i].collider.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                //getting direction to push enemy away from player
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

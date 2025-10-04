using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    //[SerializeField] private float speed = 1f;
    [SerializeField] private GameObject enemy;
    private Rigidbody2D _enemyRigidBody;

    void Start()
    {
        _enemyRigidBody = enemy.GetComponent<Rigidbody2D>();
    }
    
    private void MoveInDirection(int direction)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveInDirection(1);
    }
}

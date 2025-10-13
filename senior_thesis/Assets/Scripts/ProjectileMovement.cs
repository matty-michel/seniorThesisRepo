using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}

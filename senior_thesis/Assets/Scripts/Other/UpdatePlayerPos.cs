using UnityEngine;

public class UpdatePlayerPos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("Collided with MovingPlatform");
            transform.SetParent(other.gameObject.transform);
            Debug.Log(transform.parent);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null);
        }
    }
}

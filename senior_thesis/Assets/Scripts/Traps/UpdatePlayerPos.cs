using UnityEngine;

public class UpdatePlayerPos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            //for error when scene is unloaded
            if (other.gameObject.activeInHierarchy)
            {
                transform.SetParent(other.gameObject.transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            //for error when scene is unloaded
            if (other.gameObject.activeInHierarchy)
            {
                transform.SetParent(null);
            }
        }
    }
}

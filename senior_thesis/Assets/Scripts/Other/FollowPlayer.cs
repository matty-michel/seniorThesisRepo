using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(30, 0, 10);
    
    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = (player.transform.position + offset);
        }
    }
}

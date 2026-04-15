using UnityEngine;

public class NextLevel : MonoBehaviour
{
    //private Collider2D _playerCollider;
    [SerializeField] private GameObject winMenu;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //freezing scene
            Time.timeScale = 0;
            //activating win menu
            winMenu.SetActive(true);
        }
    }
}

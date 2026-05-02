using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject winMenu;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //freezing scene
            //Time.timeScale = 0;
            //activating win menu
            winMenu.SetActive(true);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] Collider2D playerCollider;
    void OnTriggerEnter2D(Collider2D other)
    {
        //loading the next level by scene index
        if (other == playerCollider)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

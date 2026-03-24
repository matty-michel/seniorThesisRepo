using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject player;
    private Health _playerHealth;

    void Start()
    {
        _playerHealth = player.GetComponent<Health>();
    }

    void Update()
    {
        if (_playerHealth._dead)
        {
            GameOver();
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void GameOver()
    {
        deathMenu.SetActive(true);
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathMenu.SetActive(false);
    }
    
    private void PauseGame()
    {
        //freezing scene
        Time.timeScale = 0;
        
        //opening pause menu
        pauseMenu.SetActive(true);
        //hiding health bar
        healthBar.SetActive(false);
    }

    public void ResumeGame()
    {
        //unfreezing scene
        Time.timeScale = 1;
        
        //closing pause menu
        pauseMenu.SetActive(false);
        //showing health bar
        healthBar.SetActive(true);
    }
}

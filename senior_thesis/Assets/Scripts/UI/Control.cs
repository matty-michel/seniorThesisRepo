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
        //getting player health
        _playerHealth = player.GetComponent<Health>();
    }

    void Update()
    {
        //activating game over screen when player dies
        if (_playerHealth._dead)
        {
            GameOver();
        }
        //activating pause menu when player presses 'P'
        else if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    public void LoadScene(string scene)
    {
        //loading a scene
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        //quitting game
        Application.Quit();
    }

    private void GameOver()
    {
        //activating game over screen
        deathMenu.SetActive(true);
    }

    public void Respawn()
    {
        //reloading current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //deactivating game over screen
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

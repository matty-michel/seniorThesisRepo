using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlMenus : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject player;
    private Health _playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //getting player health
        _playerHealth = player.GetComponent<Health>();
    }

    // Update is called once per frame
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
    
    private void GameOver()
    {
        //activating game over screen
        deathMenu.SetActive(true);
        //play sound
    }

    public void Respawn()
    {
        StartCoroutine(DelayRespawn());
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

    private IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(0.5f);
        //reloading current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //deactivating game over screen
        deathMenu.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class ControlMenus : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject healthBar;
    
    private GameObject _player;
    private Health _playerHealth;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        //getting player health
        _playerHealth = _player.GetComponent<Health>();
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
    
    public void GameOver()
    {
        //freezing scene
        Time.timeScale = 0;
        
        //activating game over screen
        deathMenu.SetActive(true);
        //play sound
    }

    public void Respawn()
    {
        _playerHealth._dead = false;
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

    public void YouWin()
    {
        //freezing scene
        Time.timeScale = 0;
        
        //opening win menu
        winMenu.SetActive(true);
        //play sound
    }

    private IEnumerator DelayRespawn()
    {
        //reloading current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        //unfreezing scene
        Time.timeScale = 1;
        //deactivating game over screen
        deathMenu.SetActive(false);
        
        yield return new WaitForSeconds(1.0f);
    }
}

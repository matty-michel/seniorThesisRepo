using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Control : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject healthBar;
    
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip youWinSound;
    
    private bool _freezeScene;

    void Update()
    {
        //activating pause menu when player presses 'P'
        if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        
        //checking if scene is frozen
        if (_freezeScene)
        {
            Time.timeScale = 0;
        }
        else if (!_freezeScene)
        {
            Time.timeScale = 1;
        }
    }
    
    public void NextLevel()
    {
        //unfreezing scene
        _freezeScene = false;
        
        //loading next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //void function that can be called from OnClick
    public void DelayedLoadScene(string scene)
    {
        StartCoroutine(Delay(scene));
    }
    
    private IEnumerator Delay(string scene)
    {
        //unfreezing scene
        _freezeScene = false;
        
        SceneManager.LoadScene(scene);
        //loading a scene after a certain amount of time has passed
        yield return new WaitForSeconds(1.0f);
    }
    
    public void Respawn()
    {
        StartCoroutine(DelayRespawn());
    }
    
    private IEnumerator DelayRespawn()
    {
        //unfreezing scene
        _freezeScene = false;
        
        //reloading current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        //deactivating game over screen
        deathMenu.SetActive(false);
        
        yield return new WaitForSeconds(1.0f);
    }
    
    private void PauseGame()
    {
        //freezing scene
        _freezeScene = true;
        
        //opening pause menu
        pauseMenu.SetActive(true);
        //hiding health bar
        healthBar.SetActive(false);
    }

    public void ResumeGame()
    {
        //unfreezing scene
        _freezeScene = false;
        
        //closing pause menu
        pauseMenu.SetActive(false);
        //showing health bar
        healthBar.SetActive(true);
    }

    public void YouWin()
    {
        //freezing scene
        _freezeScene = true;
        
        //opening win menu
        winMenu.SetActive(true);
        
        //play sound
        //SoundManager.Instance.PlayAudio(youWinSound);
    }
        
    public void GameOver()
    {
        //freezing scene
        _freezeScene = true;
        
        //activating game over screen
        deathMenu.SetActive(true);
        
        //play sound
        //SoundManager.Instance.PlayAudio(gameOverSound);
    }
    
    public void Quit()
    {
        //quitting game
        Application.Quit();
    }
}

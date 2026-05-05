using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Control : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject controls;
    
    private bool _freezeScene;
    private float _timesPlayed;

    void Update()
    {
        //activating pause menu when player presses 'P' -- not allowing pause when in main menu
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                PauseGame();
            }
            
            //controls only show on screen at the beginning of level before player has moved
            if(Input.anyKeyDown)
            {
                controls.SetActive(false); 
            }
        }
        
        //checking if scene is frozen
        if (_freezeScene)
        {
            Time.timeScale = 0;
            //disabling player movement in levels when frozen
            if (player != null)
            {
                player.GetComponent<PlayerController>().enabled = false; 
            }
        }
        else if (!_freezeScene)
        {
            Time.timeScale = 1;
            //enabling player movement in levels when unfrozen
            if (player != null)
            {
                player.GetComponent<PlayerController>().enabled = true;
            }
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
        //reloading current level
        DelayedLoadScene(SceneManager.GetActiveScene().name);
        
        //deactivating game over screen
        deathMenu.SetActive(false);
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
        StartCoroutine(DelayYouWin());
    }
        
    public void GameOver()
    {
        StartCoroutine(DelayGameOver());
    }

    IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(1.0f);
        
        //freezing scene
        _freezeScene = true;
        
        //activating death menu
        deathMenu.SetActive(true);
    }
    
    IEnumerator DelayYouWin()
    {
        yield return new WaitForSeconds(2.0f);
        
        //freezing scene
        _freezeScene = true;
        
        //activating win menu
        winMenu.SetActive(true);
    }
    
    public void Quit()
    {
        //quitting game
        Application.Quit();
    }
}

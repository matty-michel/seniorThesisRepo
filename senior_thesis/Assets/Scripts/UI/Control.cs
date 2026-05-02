using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Control : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        //loading a scene immediately
        SceneManager.LoadScene(scene);
    }
    
    public void NextLevel()
    {
        //loading next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //void function that can be called from OnClick
    public void DelayedLoadScene(string scene)
    {
        StartCoroutine(Delay(scene));
    }

    public void Quit()
    {
        //quitting game
        Application.Quit();
    }

    private IEnumerator Delay(string scene)
    {
        SceneManager.LoadScene(scene);
        //unfreezing scene
        Time.timeScale = 1;
        //loading a scene after a certain amount of time has passed
        yield return new WaitForSeconds(1.0f);
    }
}

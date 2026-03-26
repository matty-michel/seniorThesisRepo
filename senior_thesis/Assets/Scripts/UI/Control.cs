using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
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
}

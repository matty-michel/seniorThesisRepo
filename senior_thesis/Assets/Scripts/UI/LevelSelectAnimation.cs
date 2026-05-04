using UnityEngine;
using System.Collections;

public class LevelSelectAnimation : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject leftPoint;
    [SerializeField] GameObject rightPoint;
    [SerializeField] GameObject cam;

    private void Update()
    {
        //moving camera left
        cam.transform.position = new Vector3(cam.transform.position.x + Time.deltaTime * -1, cam.transform.position.y, cam.transform.position.z);
    }

    //public OnClick events
    public void MoveToLevelSelect()
    {
        StartCoroutine(MoveLeft());
    }

    public void MoveToMainMenu()
    {
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveLeft()
    {
        //moving menus left 
        while (mainMenu.transform.position.x >= leftPoint.transform.position.x)
        {
            mainMenu.transform.position = new Vector3(mainMenu.transform.position.x + Time.deltaTime * leftPoint.transform.position.x, mainMenu.transform.position.y, mainMenu.transform.position.z);
            
            yield return new WaitForEndOfFrame();
        }
    }
    
    IEnumerator MoveRight()
    {
        //moving menus right
        while (mainMenu.transform.position.x <= rightPoint.transform.position.x)
        {
            mainMenu.transform.position = new Vector3(mainMenu.transform.position.x + Time.deltaTime * rightPoint.transform.position.x, mainMenu.transform.position.y, mainMenu.transform.position.z);
            
            yield return new WaitForEndOfFrame();
        }
    }
}

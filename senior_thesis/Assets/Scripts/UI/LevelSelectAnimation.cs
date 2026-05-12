using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectAnimation : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelSelect;
    [SerializeField] GameObject leftPoint;
    [SerializeField] GameObject rightPoint;
    [SerializeField] GameObject cam;

    [SerializeField] private Button play;

    [SerializeField] private Button back;
    [SerializeField] private Button lvl1;
    [SerializeField] private Button lvl2;
    [SerializeField] private Button lvl3;
    [SerializeField] private Button lvl4;

    private void Start()
    {
        rightPoint.transform.position = new Vector3((mainMenu.transform.position.x + levelSelect.transform.position.x) * 0.5f, mainMenu.transform.position.y, mainMenu.transform.position.z);
        leftPoint.transform.position = new Vector3((mainMenu.transform.position.x - levelSelect.transform.position.x) * 2, mainMenu.transform.position.y, mainMenu.transform.position.z);
    }

    private void FixedUpdate()
    {
        //moving camera left
        cam.transform.position = new Vector3(cam.transform.position.x + Time.deltaTime * -1, cam.transform.position.y, cam.transform.position.z);
    }

    //public OnClick events
    public void MoveToLevelSelect()
    {
        //disabling all buttons while menus move
        DisableButtons();
        
        StartCoroutine(MoveLeft());
    }

    public void MoveToMainMenu()
    {
        //disabling all buttons while menus move
        DisableButtons();
        
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveLeft()
    {
        //moving menus left 
        while (mainMenu.transform.position.x >= leftPoint.transform.position.x)
        {
            mainMenu.transform.position = new Vector3(mainMenu.transform.position.x + Time.deltaTime * leftPoint.transform.position.x * 2, mainMenu.transform.position.y, mainMenu.transform.position.z);
            
            yield return new WaitForEndOfFrame();
        }
        
        //re-enabling level select buttons after moving to level select
        back.interactable = true;
        lvl1.interactable = true;
        lvl2.interactable = true;
        lvl3.interactable = true;
        lvl4.interactable = true;
    }
    
    IEnumerator MoveRight()
    {
        //moving menus right
        while (mainMenu.transform.position.x <= rightPoint.transform.position.x)
        {
            mainMenu.transform.position = new Vector3(mainMenu.transform.position.x + Time.deltaTime * rightPoint.transform.position.x, mainMenu.transform.position.y, mainMenu.transform.position.z);
            
            yield return new WaitForEndOfFrame();
        }
        
        //re-enabling play button after moving to main menu
        play.interactable = true;
    }

    private void DisableButtons()
    {
        play.interactable = false;
        back.interactable = false;
        lvl1.interactable = false;
        lvl2.interactable = false;
        lvl3.interactable = false;
        lvl4.interactable = false;
    }
}

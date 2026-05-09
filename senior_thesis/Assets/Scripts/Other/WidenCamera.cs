using System;
using UnityEngine;

public class WidenCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject sky;
    [SerializeField] private GameObject clouds;
    [SerializeField] private GameObject hills;
    [SerializeField] private GameObject trees1;
    [SerializeField] private GameObject trees2;
    
    private Camera bigCamera;
    
    void Start()
    {
        bigCamera = GetComponent<Camera>();
        
        //disabling wider camera at start
        bigCamera.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //enabling wider camera when player triggers collider
        if (other.CompareTag("Player"))
        {
            bigCamera.enabled = true;
            mainCamera.enabled = false;

            sky.GetComponent<RepeatBackground>()._speedModifier = 0.5f;
            clouds.GetComponent<RepeatBackground>()._speedModifier = 0.5f;
            hills.GetComponent<RepeatBackground>()._speedModifier = 0.5f;
            trees1.GetComponent<RepeatBackground>()._speedModifier = 0.5f;
            trees2.GetComponent<RepeatBackground>()._speedModifier = 0.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //disabling wider camera when player leaves the collider
        if (other.CompareTag("Player"))
        {
            mainCamera.enabled = true;
            bigCamera.enabled = false;
            
            sky.GetComponent<RepeatBackground>()._speedModifier = 1f;
            clouds.GetComponent<RepeatBackground>()._speedModifier = 1f;
            hills.GetComponent<RepeatBackground>()._speedModifier = 1f;
            trees1.GetComponent<RepeatBackground>()._speedModifier = 1f;
            trees2.GetComponent<RepeatBackground>()._speedModifier = 1f;
        }
    }
}

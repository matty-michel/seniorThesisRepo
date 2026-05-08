using System;
using UnityEngine;

public class WidenCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //disabling wider camera when player leaves the collider
        if (other.CompareTag("Player"))
        {
            mainCamera.enabled = true;
            bigCamera.enabled = false;
        }
    }
}

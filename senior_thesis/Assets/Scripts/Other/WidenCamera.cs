using System;
using UnityEngine;

public class WidenCamera : MonoBehaviour
{
    [SerializeField] private Camera widerCamera;
    private Camera _mainCamera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //disabling wider camera at start
        widerCamera.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //enabling wider camera when player triggers collider
        if (other.CompareTag("Player"))
        {
            widerCamera.enabled = true;
            _mainCamera.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //disabling wider camera when player leaves the collider
        if (other.CompareTag("Player"))
        {
            _mainCamera.enabled = true;
            widerCamera.enabled = false;
        }
    }
}

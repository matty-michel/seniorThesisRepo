using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isBlocking;
    private Health _playerHealth;
    private PlayerController _playerController;
    private PlayerAttack _playerAttack;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //getting player movement & combat scripts
        _playerHealth = GetComponent<Health>();
        _playerController = GetComponent<PlayerController>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        //blocking when player holds shift & is grounded
        if (Input.GetKey(KeyCode.LeftShift) && _playerController.isOnGround)
        {
            isBlocking = true;
            Blocking();
        }
        else
        {
            isBlocking = false;
            NotBlocking();
        }
    }

    private void Blocking()
    {
        //disabling movement & combat scripts
        _playerController.enabled = false;
        _playerHealth.enabled = false;
        _playerAttack.enabled = false;
    }
    
    private void NotBlocking()
    {
        //re-enabling scripts when player stops blocking
        _playerController.enabled = true;
        _playerHealth.enabled = true;
        _playerAttack.enabled = true;
    }
}

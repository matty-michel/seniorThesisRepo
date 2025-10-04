using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
       currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        //subtracting damage from health
        //limits health to a min of 0 and a max of _maxHealth
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        
        if (currentHealth > 0)
        {
            //player alive
        }
        else
        {
            //player dead
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}

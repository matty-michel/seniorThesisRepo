using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxHealth = 3f;
    private float _currentHealth;

    void Start()
    {
       _currentHealth = _maxHealth; 
    }

    public void DealDamage(float damage)
    {
        if (_maxHealth == 0) return;
        //subtracting damage from health
        //prevents health from going below 0
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);
    }
}

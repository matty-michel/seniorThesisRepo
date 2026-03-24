using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth = 3;
    public int currentHealth;
    public bool _dead;
    [SerializeField] private GameObject healthBarObj;
    private HealthBar _healthBar;

    void Start()
    {
       currentHealth = maxHealth;
       if (gameObject.CompareTag("Player"))
       {
           _healthBar = healthBarObj.GetComponent<HealthBar>();
           _healthBar.SetMaxHealth(maxHealth);
       }
    }

    public void TakeDamage(int damage)
    {
        //subtracting damage from health
        //limits health to a min of 0 and a max of _maxHealth
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        Debug.Log("current health: " + currentHealth);
        Debug.Log("damage: " + damage);
        
        if (currentHealth > 0)
        {
            //alive
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        //subtracting damage from health
        //limits health to a min of 0 and a max of _maxHealth
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        //updating health bar
        _healthBar.SetHealth(currentHealth);
        
        if (currentHealth > 0)
        {
            //alive
        }
        else
        {
            gameObject.SetActive(false);
            //death screen
            //SceneManager.LoadScene("Death Menu");
            _dead = true;
            //move player object to respawn point
        }
    }
}

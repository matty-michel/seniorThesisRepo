using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    public int currentHealth;
    private bool _dead;

    void Start()
    {
       currentHealth = maxHealth; 
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
            if (!_dead)
            {
                //player dead
                //disabling player controller script so player can no longer move
                if (gameObject.GetComponent<PlayerController>() != null)
                {
                    gameObject.GetComponent<PlayerController>().enabled  = false;  
                }
            
                //enemy dead
                //disabling enemy scripts so enemy can no longer move
                Destroy(gameObject);
                /*if (gameObject.GetComponentInParent<EnemyPatrol>() != null)
                {
                    gameObject.GetComponentInParent<EnemyPatrol>().enabled = false;
                }

                if (gameObject.GetComponent<Enemy>() != null)
                {
                    gameObject.GetComponent<Enemy>().enabled = false;
                }*/

                _dead = true;
            }
        }
    }
}

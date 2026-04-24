using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth = 3;
    [SerializeField] private AudioClip playerHitSound;
    [SerializeField] private AudioClip enemyHitSound;
    
    private GameObject _healthBarObj;
    private Animator _animator;
    public int currentHealth;
    public bool _dead;
    private HealthBar _healthBar;

    void Start()
    {
        //setting current health to max
       currentHealth = maxHealth;
       _animator = GetComponent<Animator>();
       
       //getting reference to health bar for player object
       if (gameObject.CompareTag("Player"))
       {
           _healthBarObj = GameObject.Find("Health Bar");
           _healthBar = _healthBarObj.GetComponent<HealthBar>();
           _healthBar.SetMaxHealth(maxHealth);
       }
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            _dead = true;
            _animator.SetTrigger("Dead");
            Destroy(gameObject, 0.5f);
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        //subtracting damage from health
        //limits health to a min of 0 and a max of _maxHealth
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        
        //play hit sound
        SoundManager.Instance.PlayAudio(enemyHitSound);
    }

    public void PlayerTakeDamage(int damage)
    {
        //subtracting damage from health
        //limits health to a min of 0 and a max of _maxHealth
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        //updating health bar
        _healthBar.SetHealth(currentHealth);

        //playing hit animation
        _animator.CrossFadeInFixedTime("Player_Hit", 0.2f);
        
        //play hit sound
        SoundManager.Instance.PlayAudio(playerHitSound);
    }
}

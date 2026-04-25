using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    [SerializeField] private AudioClip collectedSound;
    
    private Animator _animator;
    private ControlMenus _controlMenus;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _controlMenus = GameObject.Find("Control").GetComponent<ControlMenus>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //add 1 to collected items
            _controlMenus.CollectStars();
            
            //play animation & sound
            _animator.SetBool("Collected", true);
            SoundManager.Instance.PlayAudio(collectedSound);
            
            //destroy collectible
            Destroy(gameObject, 0.5f);
        }
    }
}

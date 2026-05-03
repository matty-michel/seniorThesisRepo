using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    [SerializeField] private AudioClip collectedSound;
    
    private Animator _animator;
    private TimedCollection _timedCollection;
    private CapsuleCollider2D _playerCollider;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _timedCollection = GameObject.Find("Control").GetComponent<TimedCollection>();
        _playerCollider = GameObject.Find("Player").GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == _playerCollider)
        {
            //add 1 to collected items
            _timedCollection.CollectStars();
            
            //play animation & sound
            _animator.SetBool("Collected", true);
            SoundManager.Instance.PlayAudio(collectedSound);
            
            //destroy collectible
            Destroy(gameObject, 0.5f);
        }
    }
}

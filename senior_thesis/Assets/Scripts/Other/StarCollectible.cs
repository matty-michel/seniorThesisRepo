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
        _timedCollection = GameObject.FindGameObjectWithTag("Control").GetComponent<TimedCollection>();
        _playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
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
            
            //disable collider so star isn't collected twice
            gameObject.GetComponent<Collider2D>().enabled = false;
            //destroy collectible
            Destroy(gameObject, 0.5f);
        }
    }
}

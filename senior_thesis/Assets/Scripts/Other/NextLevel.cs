using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject confetti;
    
    private Control _control;

    void Start()
    {
        _control = GameObject.Find("Control").GetComponent<Control>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            confetti.SetActive(true);
            _control.YouWin();
        }
    }
}

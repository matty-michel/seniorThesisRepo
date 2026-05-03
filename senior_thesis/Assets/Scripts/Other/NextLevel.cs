using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private Control _control;

    void Start()
    {
        _control = GameObject.Find("Control").GetComponent<Control>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _control.YouWin();
        }
    }
}

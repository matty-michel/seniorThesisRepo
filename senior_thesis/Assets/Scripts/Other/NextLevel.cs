using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private ControlMenus _controlMenus;

    void Start()
    {
        _controlMenus = GameObject.Find("Control").GetComponent<ControlMenus>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _controlMenus.YouWin();
        }
    }
}

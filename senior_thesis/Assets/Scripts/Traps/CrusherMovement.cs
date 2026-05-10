using System.Collections;
using UnityEngine;

public class CrusherMovement : MonoBehaviour
{
    [SerializeField] GameObject upperEdge;
    [SerializeField] GameObject lowerEdge;
    [SerializeField] private GameObject crusher;
    
    [SerializeField] private float downSpeed;
    [SerializeField] private float upSpeed;
    [SerializeField] float waitTime;
    
    private bool _triggered;
    private float _countDown;

    void Start()
    {
        _countDown = waitTime;
    }
    void Update()
    {
        //starting countdown when player has triggered crusher
        if (_triggered)
        {
            _countDown -= Time.deltaTime;
            Debug.Log(waitTime);
        }
    }

    void Move(int direction, float speed)
    {
        crusher.transform.position = new Vector3(crusher.transform.position.x, crusher.transform.position.y + Time.deltaTime * speed * direction, crusher.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //only triggering after crusher has finished its last trigger
        if (!_triggered)
        {
            if (other.CompareTag("Player"))
            {
                _triggered = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _triggered)
        {
            //only moving crusher down after player has stood beneath it long enough
            if (_countDown <= 0f)
            {
                StartCoroutine(Crush());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //resetting triggered and countdown when player leaves crusher collider
        _triggered = false;
        _countDown = waitTime;
    }

    private IEnumerator Crush()
    {
        yield return new WaitForSeconds(1f);
        
        //move down
        while (crusher.transform.position.y >= lowerEdge.transform.position.y)
        {
            Move(-1, downSpeed);
            yield return new WaitForEndOfFrame();
        }
        
        //pause at the bottom
        yield return new WaitForSeconds(2f);
        
        //move back up
        while (crusher.transform.position.y <= upperEdge.transform.position.y)
        {
            Move(1, upSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
}

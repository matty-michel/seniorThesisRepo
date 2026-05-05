using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private GameObject followObject;
    
    private float _startPos;
    private float _length;
    
    private float _distance;
    private float _movement;
    
    void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void FixedUpdate()
    {
        if (followObject != null)
        {
            //calculating background movement based on camera movement -- speed between 1 & 0, 1 being stationary & 0 moving with cam
            _distance = followObject.transform.position.x * speed;
            _movement = followObject.transform.position.x * (1 - speed);

            //adding distance to position
            transform.position = new Vector3(_startPos + _distance, transform.position.y, transform.position.z);

            //adjust background position if camera reaches the edge
            if (_movement > _startPos + _length)
            {
                _startPos += _length;
            }
            else if (_movement < _startPos - _length)
            {
                _startPos -= _length;
            }
        }
    }
}
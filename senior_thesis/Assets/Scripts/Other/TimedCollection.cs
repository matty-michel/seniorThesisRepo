using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class TimedCollection : MonoBehaviour
{
    [SerializeField] private GameObject stars;
    [SerializeField] private TextMeshProUGUI collectedStars;
    [SerializeField]private TextMeshProUGUI totalStars;
    
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private float timeLeft;
    
    private Control _control;
    private int _starCount;
    private int _currentStars;

    void Start()
    {
        //finding total number of star collectibles in scene
        _starCount = GameObject.FindGameObjectsWithTag("Star").Length;
        totalStars.text = _starCount.ToString();
        
        _currentStars = 0;
            
        _control = gameObject.GetComponentInParent<Control>();
    }

    void Update()
    {
        //updating timer
        timeLeft -= Time.deltaTime;
        //formats the string to only show whole numbers
        timer.text = timeLeft.ToString("0");
        
        if (_currentStars == _starCount)
        {
            //player won game
            _control.YouWin();
            
            //disable timer text
            stars.gameObject.SetActive(false);
        }
        else if (timeLeft <= 0 && _currentStars < _starCount)
        {
            //player lost game
            _control.GameOver();
            
            //disable timer text
            stars.gameObject.SetActive(false);
        }
    }
    
    public void CollectStars()
    {
        //adding 1 to collected star count
        _currentStars++;
        collectedStars.text = _currentStars.ToString();
    }
}

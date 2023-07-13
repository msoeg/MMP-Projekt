using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private int _playerHealth;
    private PlayerHealth _playerHealthObject;
    private Timer _timer;
    private string _remainingTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerHealthObject = GameObject.Find("Player").GetComponent<PlayerHealth>();
        _timer = GameObject.Find("GlobalTimeHandler").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerHealth = _playerHealthObject.GetPlayerHealth();
        if (_playerHealth <= 0)
        {
            SceneManager.LoadScene("Ending_2");
        }

        _remainingTime = _timer.remainingTime;
        if (_remainingTime.Equals("00:00"))
        {
            SceneManager.LoadScene("Ending_1");
        }
    }
}

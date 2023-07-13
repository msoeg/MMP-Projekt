using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string currentTime;
    private float _startTime;
    private float _timerDuration = 600f; // 10 minutes in seconds
    private AudioSource _gongSound;
    private ulong audioDelay;

    private void Start()
    {
        _startTime = Time.time;
        _gongSound = GetComponent<AudioSource>();
        audioDelay = 0;
    }

    private void Update()
    {
        float elapsedTime = Time.time - _startTime;
        float remainingTime = _timerDuration - elapsedTime;

        if (remainingTime > 0)
        {
            int minutes = (int)(remainingTime / 60);
            int seconds = (int)(remainingTime % 60);
            currentTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            currentTime = "10:00"; // Timer reached 10 minutes
        }
        if(currentTime.Contains(":00") && !currentTime.Contains("10:") && _gongSound != null){
            
            _gongSound.Play(audioDelay);
        }
    }
}
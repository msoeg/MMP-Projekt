using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string remainingTime;
    public float timerDuration = 600f; // 10 minutes in seconds
    private float _startTime;
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
        float remainingTime = timerDuration - elapsedTime;

        if (remainingTime > 0)
        {
            int minutes = (int)(remainingTime / 60);
            int seconds = (int)(remainingTime % 60);
            this.remainingTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            this.remainingTime = "00:00"; // Timer reached 10 minutes
        }
        if(this.remainingTime.Contains(":00") && !this.remainingTime.Contains("10:") && _gongSound != null){
            
            _gongSound.Play(audioDelay);
        }
    }
}
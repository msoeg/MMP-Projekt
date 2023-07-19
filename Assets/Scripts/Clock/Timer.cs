using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string remainingTime;
    public static string RemainingTimeStatic;
    public float timerDuration = 600f; // 10 minutes in seconds
    private float _startTime;
    private AudioSource _gongSound;
    private ulong audioDelay;
    private SpriteRenderer wallpaperSprite;
    public Sprite secondWall;
    public Sprite thirdWall;

    private void Start()
    {
        _startTime = Time.time;
        _gongSound = GetComponent<AudioSource>();
        audioDelay = 0;
        wallpaperSprite = GameObject.Find("Wallpaper").GetComponent<SpriteRenderer>();
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
            RemainingTimeStatic = this.remainingTime;
        }
        else
        {
            this.remainingTime = "00:00"; // Timer reached 10 minutes
            RemainingTimeStatic = this.remainingTime;
        }
        if(this.remainingTime.Contains(":00") && !this.remainingTime.Contains("10:") && _gongSound != null){
            
            _gongSound.Play(audioDelay);
        }
        if( wallpaperSprite != null && secondWall != null && thirdWall != null){
            if(this.remainingTime.Contains("04:00"))
            {
                Debug.Log("Wallpaper Change 1 - 2 a.m.");
                wallpaperSprite.sprite = secondWall;
            }else if(this.remainingTime.Contains("02:00"))
            {   
                Debug.Log("Wallpaper Change 2 - 4 a.m.");
                wallpaperSprite.sprite = thirdWall;
            }
        }else{
            Debug.Log("Is leer");
        }
    }
}
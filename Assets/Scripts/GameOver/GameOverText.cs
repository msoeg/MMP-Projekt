using System;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    public float letterDelay = 0.1f; // Delay between each letter appearing
    public float animationDuration = 1f; // Duration of the animation for each letter
    public AnimationCurve animationCurve; // Animation curve to control the animation

    private TextMeshProUGUI textMesh;
    private float timer;
    private int visibleCharacterCount;
    private string _remainingTime;
    private string _survivedTimeString;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.maxVisibleCharacters = 0; // Start with no visible characters
        timer = 0f;
        visibleCharacterCount = 0;
        _survivedTimeString = CalculateSurvivedTimeString();

        Debug.Log("You survived " + _survivedTimeString);
    }

    public string CalculateSurvivedTimeString()
    {
        string startTime = "10:00";
        _remainingTime = Timer.RemainingTimeStatic;
        DateTime remainingDateTime = DateTime.ParseExact(_remainingTime, "HH:mm", null);
        DateTime startDateTime = DateTime.ParseExact(startTime, "HH:mm", null);
        TimeSpan survivedTime = startDateTime - remainingDateTime;
        string survivedTimeString = survivedTime.ToString(@"hh\:mm");
        if (!string.IsNullOrEmpty(survivedTimeString)) {
   	        return survivedTimeString;
        }
        return "0";
    }

    private void Update()
    {
        if (visibleCharacterCount < textMesh.text.Length)
        {
            timer += Time.deltaTime;

            if (timer >= letterDelay)
            {
                timer = 0f;
                visibleCharacterCount++;

                // Calculate the progress of the animation using the animation curve
                float progress = animationCurve.Evaluate((float)visibleCharacterCount / textMesh.text.Length);
                textMesh.maxVisibleCharacters = Mathf.RoundToInt(progress * textMesh.text.Length);
            }
        }
        else
        {
            // Animation finished, ensure all characters are visible
            textMesh.maxVisibleCharacters = textMesh.text.Length;
        }
    }
}

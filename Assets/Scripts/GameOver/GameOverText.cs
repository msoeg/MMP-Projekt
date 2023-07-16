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

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.maxVisibleCharacters = 0; // Start with no visible characters
        timer = 0f;
        visibleCharacterCount = 0;
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

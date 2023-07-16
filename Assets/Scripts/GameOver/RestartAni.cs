using UnityEngine;

public class RestartAni : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public float animationDuration = 3f;
    public float startPosition = -1500f;
    public float endPosition = 0f;
    public float bounceHeight = 100f;

    private void Start()
    {
        // Move the initial position of the RectTransform to the start position
        Vector2 initialPosition = targetRectTransform.anchoredPosition;
        initialPosition.x = startPosition;
        targetRectTransform.anchoredPosition = initialPosition;

        // Start the animation coroutine
        StartCoroutine(MoveGameObject());
    }

    private System.Collections.IEnumerator MoveGameObject()
    {
        // Calculate the current time and set the starting time
        float currentTime = 0f;

        while (currentTime < animationDuration)
        {
            // Update the current time
            currentTime += Time.deltaTime;

            // Calculate the normalized time
            float normalizedTime = Mathf.Clamp01(currentTime / animationDuration);

            // Apply smooth step interpolation with easing effect
            float easedTime = Mathf.SmoothStep(0f, 1f, normalizedTime);
            float positionX = Mathf.Lerp(startPosition, endPosition, easedTime);
            
            // Add bounce effect at the end
            if (normalizedTime >= 1f)
            {
                float bounceOffset = Mathf.Sin((normalizedTime - 1f) * Mathf.PI) * bounceHeight;
                positionX += bounceOffset;
            }

            // Update the position of the RectTransform
            Vector2 newPosition = targetRectTransform.anchoredPosition;
            newPosition.x = positionX;
            targetRectTransform.anchoredPosition = newPosition;

            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowAnimation : MonoBehaviour
{
    public RectTransform textRectTransform;  // Reference to the text's RectTransform component
    public float moveDistance = 50f;         // Distance to move the text
    public float moveSpeed = 1.0f;           // Speed of the movement

    private Vector3 startPosition;           // Starting position of the text

    private void Start()
    {
        // Store the starting position of the text
        startPosition = textRectTransform.anchoredPosition3D;
    }

    private void Update()
    {
        // Calculate the new position of the text using an ease-in-out animation
        float t = Mathf.PingPong(Time.time * moveSpeed, 1.0f);
        float newX = startPosition.x + moveDistance * Mathf.SmoothStep(0.0f, 1.0f, t);

        // Update the text's position
        Vector3 newPosition = new Vector3(newX, startPosition.y, startPosition.z);
        textRectTransform.anchoredPosition3D = newPosition;
    }
}

using UnityEngine;

public class ClockHour : MonoBehaviour
{
    public float rotationDuration = 600f; // Dauer der Rotation in Sekunden = 10 Minuten
    private float startRotation = 0f; // Startwert der Rotation
    private float endRotation = -300f; // Endwert der Rotation
    private float rotationProgress = 0f; // Fortschritt der Rotation

    private void Update()
    {
        rotationProgress += Time.deltaTime;
        if (rotationProgress > rotationDuration)
        {
            rotationProgress = rotationDuration; // Begrenze den Fortschritt auf die Dauer der Rotation
        }

        float t = rotationProgress / rotationDuration; // Berechne den Interpolationsfaktor

        float currentRotation = Mathf.Lerp(startRotation, endRotation, t); // Interpoliere zwischen Start- und Endrotation

        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation); // Setze die Rotation des Sprites
    }
}

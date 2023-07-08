using UnityEngine;

public class ClockDong : MonoBehaviour
{
    public float amplitude = 8f; // maximale Auslenkung des Pendels
    public float duration = 600f; // Gesamtdauer der Animation in Sekunden (hier 10 Minuten = 600 Sekunden)

    private float timer = 0f;
    private bool forward = true;
    private float speed = 1f;

    void Update()
    {
        timer += Time.deltaTime;

        if (forward)
        {
            float zRotation = Mathf.Lerp(-amplitude, amplitude, timer / speed);
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

            if (timer >= speed)
            {
                forward = false;
                timer = 0f;
            }
        }
        else
        {
            float zRotation = Mathf.Lerp(amplitude, -amplitude, timer / speed);
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

            if (timer >= speed)
            {
                forward = true;
                timer = 0f;
            }
        }

        if (timer >= duration)
        {
            // Animation endet nach der angegebenen Gesamtdauer
            timer = duration;
            enabled = false; // Deaktiviert dieses Skript
        }

    }
}

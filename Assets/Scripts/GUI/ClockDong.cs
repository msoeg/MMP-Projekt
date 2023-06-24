using UnityEngine;

public class ClockDong : MonoBehaviour
{
    public float amplitude = 8f; // maximale Auslenkung des Pendels
    public float duration = 600f; // Gesamtdauer der Animation in Sekunden (hier 10 Minuten = 600 Sekunden)

    private float timer = 0f;
    private bool forward = true;
    private float minute = 10f;

    void Update()
    {
        timer += Time.deltaTime;

        if (forward)
        {
            float zRotation = Mathf.Lerp(-amplitude, amplitude, timer / 3f);
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

            if (timer >= 3f)
            {
                forward = false;
                timer = 0f;
            }
        }
        else
        {
            float zRotation = Mathf.Lerp(amplitude, -amplitude, timer / 3f);
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

            if (timer >= 3f)
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

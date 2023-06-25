using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsRotation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float rotationSpeed = 10f;
    public float hoverScale = 1.2f;
    public float scaleSpeed = 5f;

    private bool isHovered = false;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        if (isHovered)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * hoverScale, scaleSpeed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, scaleSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class ExitHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float hoverScale = 1.2f;
    public float scaleSpeed = 5f;
    public float moveSpeed = 10f;
    
    private bool isHovered = false;
    private Vector3 originalScale;
    private Vector3 targetPosition;
    private Vector3 initialPosition;
    private bool isMoving = false;

    public RectTransform textToMove;

    private void Start()
    {
        originalScale = transform.localScale;
        initialPosition = textToMove.localPosition;
        targetPosition = initialPosition;
    }

    private void Update()
    {
        if (isHovered)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * hoverScale, scaleSpeed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, scaleSpeed * Time.deltaTime);
        }

        if (isMoving)
        {
            textToMove.localPosition = Vector3.Lerp(textToMove.localPosition, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(textToMove.localPosition, targetPosition) < 0.01f)
            {
                textToMove.localPosition = targetPosition;
                isMoving = false;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        targetPosition = initialPosition + new Vector3(20f, 0f, 0f);
        isMoving = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        targetPosition = initialPosition;
        isMoving = true;
    }
}

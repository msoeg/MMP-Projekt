using UnityEngine;

public class ObjectEventHandler : MonoBehaviour
{
    public bool isEventActive;
    public Sprite activeSprite;
    public Sprite inactiveSprite;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D triggerCollider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Create a new BoxCollider2D component
        triggerCollider = gameObject.AddComponent<BoxCollider2D>();
        triggerCollider.isTrigger = true;
        triggerCollider.enabled = false;

        // Set the size of the BoxCollider2D
        triggerCollider.size = new Vector2(1f, 1f);

        // Initialize the sprite to the inactive sprite
        if (spriteRenderer != null && inactiveSprite != null)
        {
            spriteRenderer.sprite = inactiveSprite;
        }
    }

    private void Update()
    {
        if (isEventActive)
        {
            // Activate the trigger collider if it's not enabled
            if (!triggerCollider.enabled)
            {
                triggerCollider.enabled = true;
                Debug.Log("Trigger box activated for " + gameObject.name);
            }

            // Change the sprite image to active sprite
            if (spriteRenderer != null && activeSprite != null)
            {
                spriteRenderer.sprite = activeSprite;
            }
        }
        else
        {
            // Deactivate the trigger collider if it's enabled
            if (triggerCollider.enabled)
            {
                triggerCollider.enabled = false;
                Debug.Log("Trigger box deactivated for " + gameObject.name);
            }

            // Change the sprite image to inactive sprite
            if (spriteRenderer != null && inactiveSprite != null)
            {
                spriteRenderer.sprite = inactiveSprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered Trigger for " + gameObject.name);
        }
    }
}

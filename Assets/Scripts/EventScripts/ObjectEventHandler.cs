using UnityEngine;

public class ObjectEventHandler : MonoBehaviour
{
    public bool isEventActive;
    public Sprite activeSprite;
    public Sprite inactiveSprite;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _triggerCollider;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // Create a new BoxCollider2D component
        _triggerCollider = gameObject.AddComponent<BoxCollider2D>();
        _triggerCollider.isTrigger = true;
        _triggerCollider.enabled = false;

        // Set the size of the BoxCollider2D
        _triggerCollider.size = new Vector2(1f, 1f);

        // Initialize the sprite to the inactive sprite
        if (_spriteRenderer != null && inactiveSprite != null)
        {
            _spriteRenderer.sprite = inactiveSprite;
        }
    }

    private void Update()
    {
        if (isEventActive)
        {
            // Activate the trigger collider if it's not enabled
            if (!_triggerCollider.enabled)
            {
                _triggerCollider.enabled = true;
                Debug.Log("Trigger box activated for " + gameObject.name);
            }

            // Change the sprite image to active sprite
            if (_spriteRenderer != null && activeSprite != null)
            {
                _spriteRenderer.sprite = activeSprite;
            }
        }
        else
        {
            // Deactivate the trigger collider if it's enabled
            if (_triggerCollider.enabled)
            {
                _triggerCollider.enabled = false;
                Debug.Log("Trigger box deactivated for " + gameObject.name);
            }

            // Change the sprite image to inactive sprite
            if (_spriteRenderer != null && inactiveSprite != null)
            {
                _spriteRenderer.sprite = inactiveSprite;
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

    public void SetEventActive()
    {
        isEventActive = true;
    }
}

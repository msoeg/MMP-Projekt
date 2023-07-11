using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private ObjectEventHandler currentTrigger; // Reference to the currently triggered ObjectEventHandler
    private EventCounter _eventCounter;
    private AudioSource _repairSound;

    private void Start()
    {
        _eventCounter = GameObject.Find("EventCounter").GetComponent<EventCounter>();
        _repairSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (currentTrigger != null && Input.GetKeyDown(KeyCode.E))
        {
            _repairSound.Play(0);
            currentTrigger.isEventActive = false;
            if (currentTrigger.SoundEffect != null && currentTrigger.SoundEffect.isPlaying)
            {
                currentTrigger.SoundEffect.Stop();
            }
            _eventCounter.DecrementCounter();
            Debug.Log("isEventActive set to False for " + currentTrigger.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ObjectEventHandler objectEventHandler = other.GetComponent<ObjectEventHandler>();
        if (objectEventHandler != null)
        {
            currentTrigger = objectEventHandler;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ObjectEventHandler objectEventHandler = other.GetComponent<ObjectEventHandler>();
        if (objectEventHandler != null && objectEventHandler == currentTrigger)
        {
            currentTrigger = null;
        }
    }
}
using System;
using UnityEngine;

public class HideInteraction : MonoBehaviour
{
    private ObjectHideHandler currentTrigger; // Reference to the currently triggered ObjectHideHandler
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (currentTrigger != null && Input.GetKeyDown(KeyCode.E))
        {
            currentTrigger.isEventActive = False;
            Debug.Log("isEventActive set to False for " + currentTrigger.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ObjectHideHandler objectHideHandler = other.GetComponent<ObjectHideHandler>();
        if (objectHideHandler != null)
        {
            currentTrigger = objectHideHandler;
        }
        objectHideHandler.isEventActive = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ObjectHideHandler objectHideHandler = other.GetComponent<ObjectHideHandler>();
        if (objectHideHandler != null && objectHideHandler == currentTrigger)
        {
            currentTrigger = null;
        }

        objectHideHandler.isEventActive = true;
    }

}
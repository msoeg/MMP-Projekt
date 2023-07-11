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
            currentTrigger.isEventActive = false;
            Debug.Log("isEventActive set to true for " + currentTrigger.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ObjectHideHandler objectHideHandler = other.GetComponent<ObjectHideHandler>();
        if (objectHideHandler != null)
        {
            currentTrigger = objectHideHandler;
        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ObjectHideHandler objectHideHandler = other.GetComponent<ObjectHideHandler>();
        if (objectHideHandler != null && objectHideHandler == currentTrigger)
        {
            currentTrigger = null;
        }

        
    }

}
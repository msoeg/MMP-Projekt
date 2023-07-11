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
        if (currentTrigger != null && Input.GetKeyDown(KeyCode.E) && currentTrigger.hidden == false)
        {
            currentTrigger.isEventActiveHide = true;
            currentTrigger.hidden = true; 
            Debug.Log("isEventActiveHide set to true for " + currentTrigger.gameObject.name);

        }else if(currentTrigger != null && Input.GetKeyDown(KeyCode.E) && currentTrigger.hidden == true)
        {
            currentTrigger.isEventActiveHide = true;
            currentTrigger.hidden = false;
            Debug.Log("isEventActiveHide set to false for " + currentTrigger.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        ObjectHideHandler objectHideHandler = other.GetComponent<ObjectHideHandler>();
        if (objectHideHandler != null)
        {
            Debug.Log("Getriggert von: "+other.name);
            currentTrigger = objectHideHandler;
                        
        }

       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ObjectHideHandler objectHideHandler = other.GetComponent<ObjectHideHandler>();
        if (objectHideHandler != null && objectHideHandler == currentTrigger)
        {
            Debug.Log("Verlässt: "+other.name);
            currentTrigger = null;
            
        }

        
    }

}
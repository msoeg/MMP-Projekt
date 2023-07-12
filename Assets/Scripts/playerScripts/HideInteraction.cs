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
        if (currentTrigger != null && Input.GetKeyDown(KeyCode.Space) && currentTrigger.hidden == false)
        {
            Debug.Log("Player is hidden");
            currentTrigger.hidden = true;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.3f);
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;

        }else if(currentTrigger != null && Input.GetKeyDown(KeyCode.Space) && currentTrigger.hidden == true)
        {
            Debug.Log("Player is not hidden");
            currentTrigger.hidden = false;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;
            this.gameObject.GetComponent<PlayerMovement>().enabled = true;
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
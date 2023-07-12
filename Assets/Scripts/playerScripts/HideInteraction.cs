using System;
using UnityEngine;
using UnityEngine.UI;

public class HideInteraction : MonoBehaviour
{
    private ObjectHideHandler currentTrigger; // Reference to the currently triggered ObjectHideHandler
    public bool isHidden;
    
    public Text intText;
    public string textValue;
    
    private void Start()
    {
        isHidden = false;
        intText.text = textValue;
        intText.enabled = false;
    }

    private void Update()
    {
        if (currentTrigger != null && Input.GetKeyDown(KeyCode.Space) && isHidden == false)
        {
            Debug.Log("Player is hidden");
            isHidden = true;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.3f);
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;

        }else if(currentTrigger != null && Input.GetKeyDown(KeyCode.Space) && isHidden == true)
        {
            Debug.Log("Player is not hidden");
            isHidden = false;
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
            intText.enabled = true;
                        
        }

       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ObjectHideHandler objectHideHandler = other.GetComponent<ObjectHideHandler>();
        if (objectHideHandler != null && objectHideHandler == currentTrigger)
        {
            Debug.Log("Verlässt: "+other.name);
            currentTrigger = null;
            intText.enabled = false;
            
        }

        
    }

}
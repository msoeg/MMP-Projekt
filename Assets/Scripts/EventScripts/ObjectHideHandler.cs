using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHideHandler : MonoBehaviour
{

    public bool isEventActive;
    public bool hidden;
    public GameObject player;
    public SpriteRenderer playerRender;
    public GameObject hidingPlace;

    private BoxCollider2D _triggerCollider;

   


    // Start is called before the first frame update
    void Start()
    {
        hidden = false;
    
        player = GameObject.Find("Player");
        playerRender = player.GetComponent<SpriteRenderer>(); 
        hidingPlace = this.gameObject;
        
        //Set Up Collider
        _triggerCollider = gameObject.AddComponent<BoxCollider2D>();
        _triggerCollider.isTrigger = true;
        _triggerCollider.enabled = false;

        // Set the size of the BoxCollider2D
        _triggerCollider.size = new Vector2(1f, 1f);
    }

    // Update is called once per frame
    void Update() 
    {

        if (isEventActive)
        {

            // Activate the trigger collider if it's not enabled
            if (!_triggerCollider.enabled)
            {
                _triggerCollider.enabled = true;
                Debug.Log("Trigger box activated for " + gameObject.name);
            }

            if(Input.GetKeyDown(KeyCode.E) && hidden == false)
            {
                    Debug.Log("Player is hidden!");
                    hidden = true;
                    playerRender.enabled = false;
                    player.GetComponent<Rigidbody2D>().simulated = false;
                    player.GetComponent<PlayerMovement>().enabled = false;
                    
            }else if(Input.GetKeyDown(KeyCode.E) && hidden == true)
            {
                    Debug.Log("Left Hidingspace!");
                    hidden = false;
                    playerRender.enabled = true;
                    player.GetComponent<Rigidbody2D>().simulated = true;
                    player.GetComponent<PlayerMovement>().enabled = true;
                    
            }else{
                Debug.Log("Nope");
            }
        }else{
            if (_triggerCollider.enabled)
            {
                _triggerCollider.enabled = false;
                Debug.Log("Trigger box deactivated for " + gameObject.name);
            }

            Debug.Log("Nope2");
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

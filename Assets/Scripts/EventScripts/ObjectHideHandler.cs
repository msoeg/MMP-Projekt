using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHideHandler : MonoBehaviour
{

    public bool isEventActiveHide;
    public bool hidden;
    public GameObject player;
    public GameObject hidingPlace;

    private BoxCollider2D _triggerCollider;
    public SpriteRenderer _playerRender;
   


    // Start is called before the first frame update
    void Start()
    {
          
        player = GameObject.Find("Player");
        _playerRender = player.GetComponent<SpriteRenderer>(); 
        hidingPlace = this.gameObject;
        
        //Set Up Collider
        _triggerCollider = gameObject.AddComponent<BoxCollider2D>();
        _triggerCollider.isTrigger = true;
        _triggerCollider.enabled = false;

        // Set the size of the BoxCollider2D
        _triggerCollider.size = new Vector2(1f, 1.8f);
    }

    // Update is called once per frame
    void Update() 
    {
        Debug.Log(_triggerCollider.enabled+ " : Start Update()");
        Debug.Log("## Object View isEventActiveHide: "+isEventActiveHide);
        if (isEventActiveHide)
        {

            Debug.Log(_triggerCollider.enabled+ " : if(isEventActiveHide())");
            // Activate the trigger collider if it's not enabled
            if (!_triggerCollider.enabled)
            {
                _triggerCollider.enabled = true;
                Debug.Log("Trigger box activated for " + gameObject.name);
            }
            Debug.Log(_triggerCollider.enabled+ " : after first if"); 

            Debug.Log("Hidden-State: "+hidden);
            if(hidden == true)
            { 
                Debug.Log("Player is hidden!");
                _playerRender.enabled = false;
                Debug.Log("Renderer: "+_playerRender.enabled);
                //player.GetComponent<CapsuleCollider2D>().enabled = false;
                player.GetComponent<PlayerMovement>().enabled = false;
                
                    
            }else{
                Debug.Log("Left Hidingspace!");
                _playerRender.enabled = true;
                Debug.Log("Renderer: "+_playerRender.enabled);
                //player.GetComponent<CapsuleCollider2D>().enabled = false;
                player.GetComponent<PlayerMovement>().enabled = true;  
            }
            
        }
        else
        {
              
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered Trigger for " + gameObject.name);
        }
    }


    public void SetEventActiveHide()
    {
        isEventActiveHide = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHideHandler : MonoBehaviour
{

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
        _triggerCollider.enabled = true;

        // Set the size of the BoxCollider2D
        _triggerCollider.size = new Vector2(1f, 1.8f);
    }

    // Update is called once per frame
    void Update() 
    {          
        
    }    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered Trigger for " + gameObject.name);
        }
    }
   
}

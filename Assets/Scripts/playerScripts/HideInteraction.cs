using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HideInteraction : MonoBehaviour
{
    private ObjectHideHandler _currentTrigger; // Reference to the currently triggered ObjectHideHandler
    private Rigidbody2D _playerRigidBody;
    private PlayerMovement _playerMovement;

    public bool isHidden;
    public SpriteRenderer playerRenderer;
    public Animator animator;

    public Text intText;
    public string textValue;
    
    private void Start()
    {
        isHidden = false;
        intText.text = textValue;
        intText.enabled = false;
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_currentTrigger != null && Input.GetKeyDown(KeyCode.Space) && !isHidden)
        {
            Debug.Log("Player is hidden");
            isHidden = true;
            playerRenderer.color = new Color(1f,1f,1f,0.3f);
            playerRenderer.sortingOrder = 2;
            ResetPlayerMovement();
            _playerMovement.enabled = false;
            animator.SetTrigger("Default");

        }else if(_currentTrigger != null && Input.GetKeyDown(KeyCode.Space) && isHidden)
        {
            Debug.Log("Player is not hidden");
            isHidden = false;
            playerRenderer.color = new Color(1f,1f,1f,1f);
            playerRenderer.sortingOrder = 100;
            playerRenderer.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    private void ResetPlayerMovement()
    {
        Vector2 newVelocity = _playerRigidBody.velocity;
        newVelocity.x = 0f;
        _playerRigidBody.velocity = newVelocity;
        animator.SetFloat("Horizontal", 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        ObjectHideHandler objectHideHandler = other.GetComponent<ObjectHideHandler>();
        if (objectHideHandler != null)
        {
            Debug.Log("Getriggert von: "+other.name);
            _currentTrigger = objectHideHandler;
            intText.enabled = true;
                        
        }

       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ObjectHideHandler objectHideHandler = other.GetComponent<ObjectHideHandler>();
        if (objectHideHandler != null && objectHideHandler == _currentTrigger)
        {
            Debug.Log("Verlässt: "+other.name);
            _currentTrigger = null;
            intText.enabled = false;
            
        }

        
    }

}
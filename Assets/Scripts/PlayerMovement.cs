using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed = 0.1f;
    private GameObject room;

    private bool canPressKey;

    void Start()
    {
        myRigidbody.freezeRotation = true;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0, 0);
        transform.position += movement;
        
        if (canPressKey)
        {
            if (Input.GetKeyDown(KeyCode.W) && transform.position.y < 0)
            {
                Vector3 goUp = new Vector3(0, 3, 0);
                transform.position += goUp;
            }
            else if (Input.GetKeyDown(KeyCode.S)&& transform.position.y > -5)
            {
                Vector3 goDown = new Vector3(0, -3, 0);
                transform.position += goDown;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stairs"))
        {
            canPressKey = true;
            Debug.Log("Can press key");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Stairs"))
        {
            canPressKey = false;
            Debug.Log("Can't press key");
        }
    }
}
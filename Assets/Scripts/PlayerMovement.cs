using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed = 0.1f;

    private bool canPressKey;
    private string stair_type = "";

    public Animator animator;

    void Start()
    {
        myRigidbody.freezeRotation = true;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", moveHorizontal);

        Vector3 movement = new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0, 0);
        transform.position += movement;
        
        if (canPressKey)
        {
            if (stair_type.Equals("StairUp"))
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Vector3 goUp = new Vector3(0, 3, 0);
                    transform.position += goUp;
                }
            } else if (stair_type.Equals("StairDown"))
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Vector3 goDown = new Vector3(0, -3, 0);
                    transform.position += goDown;
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StairUp"))
        {
            canPressKey = true;
            stair_type = "StairUp";
            Debug.Log("Can press key");
        } else if (other.CompareTag("StairDown"))
        {
            canPressKey = true;
            stair_type = "StairDown";
            Debug.Log("Can press key");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("StairUp"))
        {
            stair_type = "StairUp";
            canPressKey = false;
            Debug.Log("Can't press key");
        } else if (other.CompareTag("StairDown"))
        {
            stair_type = "StairDown";
            canPressKey = false;
            Debug.Log("Can't press key");
        }
    }
}
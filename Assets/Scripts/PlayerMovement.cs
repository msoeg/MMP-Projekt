using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed;
    public CapsuleCollider2D capsuleCollider;

    private bool canPressKey;
    private string stair_type = "";
    private bool isMoving;
    private Vector3 targetPosition;
    private bool canMoveHorizontally = true;

    public Animator animator;

    void Start()
    {
        myRigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (canMoveHorizontally && !isMoving)
        {
            animator.SetFloat("Horizontal", moveHorizontal);
            Vector3 movement = new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0, 0);
            transform.position += movement;
        }

        HandleInput();
        if(isMoving) MovePlayer();
    }

    private void HandleInput()
    {
        if (canPressKey)
        {
            if (!isMoving)
            {
                if (canMoveHorizontally)
                {
                    if (stair_type.Equals("StairUp") &&
                        (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
                    {
                        Vector3 goUp = new Vector3(0f, 3f, 0f);
                        targetPosition = transform.position + goUp;
                        capsuleCollider.enabled = false;
                        isMoving = true;
                        animator.SetTrigger("TrClimb");

                    }
                    else if (stair_type.Equals("StairDown") &&
                             (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
                    {
                        Vector3 goDown = new Vector3(0f, -3f, 0f);
                        targetPosition = transform.position + goDown;
                        capsuleCollider.enabled = false;
                        isMoving = true;
                        animator.SetTrigger("TrClimb");
                    }
                    else if (stair_type.Equals("StairDiagUp") &&
                             (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
                    {
                        Vector3 goUp = new Vector3(3.5f, 3f, 0f);
                        targetPosition = transform.position + goUp;
                        capsuleCollider.enabled = false;
                        isMoving = true;
                        animator.SetTrigger("TrStairUp");
                    }
                    else if (stair_type.Equals("StairDiagDown") &&
                             (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
                    {
                        Vector3 goDown = new Vector3(-3.5f, -3f, 0f);
                        targetPosition = transform.position + goDown;
                        capsuleCollider.enabled = false;
                        isMoving = true;
                        animator.SetTrigger("TrStairDown");
                    }
                }
            }
        }
    }
    
    private void MovePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the player has reached the target position
        if (transform.position == targetPosition)
        {
            capsuleCollider.enabled = true;
            animator.SetTrigger("Default");
            isMoving = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StairUp"))
        {
            canPressKey = true;
            stair_type = "StairUp";
            Debug.Log("Can press key");
        }
        else if (other.CompareTag("StairDown"))
        {
            canPressKey = true;
            stair_type = "StairDown";
            Debug.Log("Can press key");
        }
        else if (other.CompareTag("StairDiagUp"))
        {
            canPressKey = true;
            stair_type = "StairDiagUp";
            Debug.Log("Can press key");
        }
        else if (other.CompareTag("StairDiagDown"))
        {
            canPressKey = true;
            stair_type = "StairDiagDown";
            Debug.Log("Can press key");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("StairUp"))
        {
            stair_type = "";
            canPressKey = false;
            Debug.Log("Can't press key");
        }
        else if (other.CompareTag("StairDown"))
        {
            stair_type = "";
            canPressKey = false;
            Debug.Log("Can't press key");
        }
        else if (other.CompareTag("StairDiagDown"))
        {
            stair_type = "";
            canPressKey = false;
            Debug.Log("Can't press key");
        }
        else if (other.CompareTag("StairDiagDown"))
        {
            stair_type = "";
            canPressKey = false;
            Debug.Log("Can't press key");
        }
    }
}
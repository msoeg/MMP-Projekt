using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed = 5f;


    void Start()
    {
        myRigidbody.freezeRotation = true;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeed;
        myRigidbody.velocity = movement;
    }
}

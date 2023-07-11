using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject room;

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("Trigger to room " + room.name + " activated");
    }
}

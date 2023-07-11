using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairCounter : MonoBehaviour
{
    private EventCounter eventCounter;

    void Start()
    {
        eventCounter = GameObject.Find("EventCounter").GetComponent<EventCounter>();

    }
    void Update()
    {
        int count = eventCounter.GetEventCount();
        Debug.Log("Event count: " + count);

    }
}

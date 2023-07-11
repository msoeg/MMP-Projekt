using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class RepairCounter : MonoBehaviour
{
    public TextMeshProUGUI counterUI;
    
    private EventCounter eventCounter;

    void Start()
    {
        eventCounter = GameObject.Find("EventCounter").GetComponent<EventCounter>();

    }
    void Update()
    {
        int count = eventCounter.GetEventCount();
        counterUI.text = count.ToString();
        Debug.Log("Event count: " + count);
    }
}

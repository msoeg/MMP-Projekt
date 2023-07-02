using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class EventCounter : MonoBehaviour
{
    [SerializeField]
    [ReadOnly]
    private int eventCount = 0;
    
    public void IncrementCounter()
    {
        eventCount++;
    }

    public void DecrementCounter()
    {
        eventCount--;
    }

    public int GetEventCount()
    {
        return eventCount;
    }
}

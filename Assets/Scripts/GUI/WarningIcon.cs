using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class WarningIcon : MonoBehaviour
{
    public GameObject yellowObject;
    public GameObject redObject;

    private EventCounter eventCounter;

    void Start()
    {
        eventCounter = GameObject.Find("EventCounter").GetComponent<EventCounter>();
    }

    void Update()
    {
        int count = eventCounter.GetEventCount();
        UpdateWarningIcons(count);
    }

    private void UpdateWarningIcons(int count)
    {
        if (count < 3)
        {
            SetObjectVisibility(yellowObject, false);
            SetObjectVisibility(redObject, false);
        }
        else if (count >= 3 && count < 5)
        {
            SetObjectVisibility(yellowObject, true);
            SetObjectVisibility(redObject, false);
        }
        else // count >= 5
        {
            SetObjectVisibility(yellowObject, false);
            SetObjectVisibility(redObject, true);
        }
    }

    private void SetObjectVisibility(GameObject obj, bool isVisible)
    {
        if (obj != null)
        {
            obj.SetActive(isVisible);
        }
        else
        {
            Debug.LogWarning("GameObject reference is null.");
        }
    }
}

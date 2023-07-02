using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventHandler : MonoBehaviour
{
    public float secondsBetweenEvents = 10f;
    private GameObject[] _eventableObjects;
    private EventCounter _eventCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        _eventableObjects = GameObject.FindGameObjectsWithTag("Eventable");
        _eventCounter = GameObject.Find("EventCounter").GetComponent<EventCounter>();
        
        // Start a coroutine to activate events every 10 seconds
        StartCoroutine(ActivateRandomEvent());
    }
    
    IEnumerator ActivateRandomEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenEvents);

            ChooseObjectForSetIsEventActive(_eventableObjects);
        }
    }

    private void ChooseObjectForSetIsEventActive(GameObject[] objectListToChoose)
    {
        // Select a random object
        GameObject randomObject = objectListToChoose[Random.Range(0, objectListToChoose.Length)];

        // Activate the event on the selected object
        ObjectEventHandler objectEventHandler = randomObject.GetComponent<ObjectEventHandler>();
        if (objectEventHandler != null)
        {
            if (!objectEventHandler.isEventActive)
            {
                objectEventHandler.SetEventActive();
                Debug.Log("Set event of " + randomObject.name + " to True");
                _eventCounter.IncrementCounter();
            }
            else
            {
                List<GameObject> remainingObjects = new List<GameObject>(objectListToChoose);
                remainingObjects.Remove(randomObject);
            
                // Call the method again with the new list
                if (remainingObjects.Count != 0)
                {
                    ChooseObjectForSetIsEventActive(remainingObjects.ToArray());
                }
                else
                {
                    Debug.Log("No inactive event left. Skipping activating event...");
                    return;
                }
            }
        }
    }
}
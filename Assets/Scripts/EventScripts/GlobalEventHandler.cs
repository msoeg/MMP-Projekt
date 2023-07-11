using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventHandler : MonoBehaviour
{
    public float waitTimeBeforeFirstEvent = 30f;
    public float minSecondsBetweenEvents = 20f;
    public float maxSecondsBetweenEvents = 60f;
    private GameObject[] _eventableObjects;
    private EventCounter _eventCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        _eventableObjects = GameObject.FindGameObjectsWithTag("Eventable");
        _eventCounter = GameObject.Find("EventCounter").GetComponent<EventCounter>();

        // Wait for 30 seconds before starting the coroutine
        StartCoroutine(DelayedCoroutine(ActivateRandomEvent(), waitTimeBeforeFirstEvent));
    }

    IEnumerator DelayedCoroutine(IEnumerator coroutine, float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(coroutine);
    }
    
    IEnumerator ActivateRandomEvent()
    {
        while (true)
        {
            float randomTime = Random.Range(minSecondsBetweenEvents, maxSecondsBetweenEvents);
            yield return new WaitForSeconds(randomTime);

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
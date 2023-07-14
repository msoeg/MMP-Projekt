using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderSize : MonoBehaviour
{

    private EventCounter eventCounter;
    public RectTransform targetRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        ChangeWidth(31.5f);
    }

    // Update is called once per frame
    void Update()
    {
        int count = eventCounter.GetEventCount();
        ChangeWidth(100f);

    }

    public void ChangeWidth(float newWidth)
    {
        Vector2 sizeDelta = targetRectTransform.sizeDelta;

        // Set the new width value
        sizeDelta.x = newWidth;

        // Apply the updated size to the RectTransform
        targetRectTransform.sizeDelta = sizeDelta;
    }
}

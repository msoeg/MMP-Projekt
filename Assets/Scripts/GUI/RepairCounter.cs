using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject otherObject = GameObject.Find("EventCounter");
        OtherScript otherScriptComponent = otherObject.GetComponent<OtherScript>();


    }

    // Update is called once per frame
    void Update()
    {
        EventCounter
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    private bool hidden;
    // Start is called before the first frame update
    void Start()
    {
        hidden = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && hidden == false){
            Debug.Log("Player is hidden!");
            hidden = true;
        }else if(Input.GetKeyDown(KeyCode.E) && hidden == true){
            Debug.Log("Left Hidingspace!");
            hidden = false;
        }

    }
}

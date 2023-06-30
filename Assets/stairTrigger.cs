using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairTrigger : MonoBehaviour
{
    public bool canPressUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered trigger");
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player exited trigger");

    }
}

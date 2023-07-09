using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    public bool hidden;
    public GameObject player;
    SpriteRenderer playerRender;
    // Start is called before the first frame update
    void Start()
    {
        hidden = false;

        if(player == null){
            player = GameObject.Find("Player");
            Debug.Log("new player Object: "+player.name);
        } 
        playerRender = player.GetComponent<SpriteRenderer>();
        Debug.Log(playerRender.name);
    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log("Before if-else");
        if(Input.GetKeyDown(KeyCode.E) && hidden == false){
            Debug.Log("Player is hidden!");
            hidden = true;
            playerRender.enabled = false;
            Debug.Log("Hidden: "+hidden);
        }else if(Input.GetKeyDown(KeyCode.E) && hidden == true){
            Debug.Log("Left Hidingspace!");
            hidden = false;
            playerRender.enabled = true;
            Debug.Log("Hidden: "+hidden);
        }
        Debug.Log("After if-else");

    }
}

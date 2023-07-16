using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class SurvivedTime : MonoBehaviour
{
    public TextMeshProUGUI survivedTime;
    private GameOverText txt;
    void Start()
    {
        txt = GameObject.Find("GameOver").GetComponent<GameOverText>();
    }

    // Update is called once per frame
    void Update()
    {
        survivedTime.text = txt.CalculateSurvivedTimeString();
    }
}

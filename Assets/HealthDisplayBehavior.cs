using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite emptyHeart;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    private PlayerHealth _playerHealth;
    private int health_count;

    public AudioSource damage;


    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Start()
    {
        health_count = _playerHealth != null ? _playerHealth.GetPlayerHealth() : 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health_count <= _playerHealth.GetPlayerHealth()) return;
            switch (health_count)
            {
                case 3:
                    heart3.sprite = emptyHeart;
                    damage.Play();
                    break;
                case 2:
                    heart2.sprite = emptyHeart;
                    damage.Play();
                    break;
                case 1:
                    heart1.sprite = emptyHeart;
                    damage.Play();
                    break;
            }
            health_count--;
        
    }
}

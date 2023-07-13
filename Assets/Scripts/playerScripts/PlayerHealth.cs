using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private void Update()
    {
        if (playerHealth <= 0)
        {
            Debug.LogWarning("Game Over!");
            // SceneManager.LoadScene("GameOver");
        }
    }

    [SerializeField]
    private int playerHealth = 3;

    public void SubtractHealth()
    {
        playerHealth = playerHealth - 1;
    }

    public void AddHealth()
    {
        playerHealth = playerHealth + 1;
    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private bool gameEnded = false;
    public GameObject gameOverUI;
    void Update()
    {
        if (gameEnded)
            return;

    }
   public void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over");
    }
}

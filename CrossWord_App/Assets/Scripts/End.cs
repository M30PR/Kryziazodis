using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public bool gameEnded = false;
    public GameObject gameOverUI;
    public static int sk;
    private void Start()
    {
        sk = 1;
    }
    void Update()
    {
        if (gameEnded)
        {
            EndGame();
        }

    }
    public void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
        trigger();
    }
    public void trigger()
    {
        sk++;
        PlayerPrefs.SetInt("levelAt", sk);
    }
}

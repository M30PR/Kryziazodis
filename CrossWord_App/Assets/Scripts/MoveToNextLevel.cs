using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextScene;
    public void Trigger()
    {
        if (nextScene > PlayerPrefs.GetInt("LevelAt"))
        {
            PlayerPrefs.SetInt("LevelAt", nextScene);
        }
    }

}

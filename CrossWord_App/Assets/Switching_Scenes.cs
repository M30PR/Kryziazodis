using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switching_Scenes : MonoBehaviour
{
    public void ChangeSecene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}

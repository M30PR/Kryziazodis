using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class name : MonoBehaviour
{
    private Behavior behavior;

    // Update is called once per frame
    public void alphabet(string name)
    {
        behavior = GameObject.FindObjectOfType<Behavior>();
        behavior.Raide(name);
    }
}

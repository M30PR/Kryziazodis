using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{
    static Galvosukis[,] crossword = new Galvosukis[9,9];
    public Generator generator;
    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.FindObjectOfType<Generator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

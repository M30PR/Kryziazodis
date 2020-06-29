using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public int width = 9;
    public int height = 9;
    public GameObject gridPrefab;
    private Generator generator;
    public Galvosukis[,] crossword = new Galvosukis[9,9];
    public int skaicius;

    public void Start()
    {
        skaicius = 0;
        generator = GameObject.FindObjectOfType<Generator>();
        crossword = generator.Gazinti();
        GridSetup();
        
    }
    void GridSetup()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
               if (crossword[i, j] != null)
               {
                    skaicius++;
                   Vector2 position2 = new Vector2(i, j);
                   GameObject obj = Instantiate(gridPrefab, position2, Quaternion.identity);
                   obj.transform.parent = this.transform;
                   obj.name = "( " + i + "," + j + " )";
                    SpriteText cell = obj.GetComponent<SpriteText>();
                    cell.InitCell("");
                }

            }
        }
    }
    public Galvosukis[,] grazinti()
    {
        return crossword;
    }
}

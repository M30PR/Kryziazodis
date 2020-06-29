using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSearch : MonoBehaviour
{
    private static int sk;
    public int count;
    public Grid grid;
    public End end;
    public int Seach()
    { 
        count = 0;
        grid = GameObject.FindObjectOfType<Grid>();
        end = GameObject.FindObjectOfType<End>();
        sk = grid.skaicius;

        for (int i = 0; i < grid.height; i++)
        {
            for (int j = 0; j < grid.width; j++)
            {
                if(grid.crossword[i,j] != null)
                {
                     string x = Find1(i, j);
                   if (grid.crossword[i,j].zodis == x)
                   {
                    count++;
                   }
                }
                
            }
        }
        if(sk == count)
        {
            end.gameEnded = true;
            return 1;
        }
        else
        {
          return 0;
        }
    }
    public string Find1(int x,int y)
    {
        string s = "( " + x + "," + y + " )";
        SpriteRenderer cell = GameObject.Find(s).GetComponent<SpriteRenderer>();
        SpriteText txt = cell.GetComponent<SpriteText>();
        string p = txt.InitCellBack();
        return p;
    }
}

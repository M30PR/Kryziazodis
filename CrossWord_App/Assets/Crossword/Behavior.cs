using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Behavior : MonoBehaviour
{
    public Color hoverColor;
    Vector2 position;
    public Color startColor;
    private SpriteRenderer rend;
    private Grid grid;
    public static int width;
    public static int height;
    private GridSearch search = new GridSearch();
    private void Awake()
    {
        grid = GameObject.FindObjectOfType<Grid>();
    }
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;
    }
    void OnMouseDown()
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Text txt = GameObject.Find("Canvas/Bottom/Uzduotis").GetComponent<Text>();
        txt.text = grid.crossword[x, y].uzduotis.ToString();
        hoverColor = rend.material.color;
        WasOnNode(x, y);
        Debug.Log(x + " " + y);
    }
    public void WasOnNode(int x, int y)
    {
        width = x;
        height = y;
    }
    public void Raide(string raide)
    {
            string s = "( " + width + "," + height + " )";
            SpriteRenderer cell = GameObject.Find(s).GetComponent<SpriteRenderer>();
            SpriteText txt = cell.GetComponent<SpriteText>();
            txt.InitCell(raide);
            search.Seach();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteText : MonoBehaviour
{
    private Text txtCellValue;

    public void InitCell(string value)
    {
        txtCellValue = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        txtCellValue.text = value; // update the GUI
    }
    public string InitCellBack()
    {
        txtCellValue = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        return txtCellValue.text;
    }
}

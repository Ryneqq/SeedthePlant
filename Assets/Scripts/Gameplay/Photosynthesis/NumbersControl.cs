using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumbersControl : MonoBehaviour {
    // wyswietla na ekranie ilosc nasionek

    public Text normalText;
    public Text ancientText;

    // Use this for initialization
    void Start()
    {
        if (normalText)
            SetNumber("Normal");
        if (ancientText)
            SetNumber("Ancient");
    }
    public void SetNumber()
    {
        normalText.text = Variables.noNormal.ToString();
        ancientText.text = Variables.noAncient.ToString();
    }

    public void SetNumber(string Type)
    {
        if (Type == "Normal")
            normalText.text = Variables.noNormal.ToString();
        else if (Type == "Ancient")
            ancientText.text = Variables.noAncient.ToString();
    }
}

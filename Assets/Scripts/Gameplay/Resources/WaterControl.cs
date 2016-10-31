using UnityEngine;
using System.Collections;

public class WaterControl : MonoBehaviour {
    private bool isPressed = false;
    private BarControl Bar;
	// Use this for initialization
	void Start () {
        Bar = GameObject.Find("Main Camera").GetComponent<BarControl>();
    }
    void Update()
    {
        if (isPressed && Variables.mode == "photo")
        {
            isPressed = false;
        }
        if (isPressed)
            WhilePressed();

    }
    public void Pressed()
    {
        isPressed = true;
    }
    public void Released()
    {
        isPressed = false;
    }
    void WhilePressed()
    {
        Bar.GainWater();
        // Poisoned Water
       /* if (GeneralVariables.PoisonedWater)
        {
            bar.GainCO2(-1);
            bar.GainLight(-1);
            bar.GainSun(-1);
        }*/ //Plaga

    }
}

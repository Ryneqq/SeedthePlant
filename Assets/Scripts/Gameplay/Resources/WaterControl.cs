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
        if (isPressed && (Variables.mode == "photo" || Variables.pause))
        {
            isPressed = false;
        }
        if (isPressed && !Variables.pause)
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
       if (Variables.poisonedWater)
        {
            Bar.GainO2(-0.01f);
            Bar.GainCO2(-0.01f);
            Bar.GainSun(-0.01f);
        }

    }
}

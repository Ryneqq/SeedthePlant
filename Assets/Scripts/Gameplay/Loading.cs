using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
	void Awake () {
        Variables.pause = false;
        Variables.mode = "normal";
        //wczytać planta
        // Loding gain statistics
        Variables.O2GainValue = 15.0f/100.0f;
        Variables.CO2GainValue = 15.0f/100.0f;
        Variables.SunGainValue = 15.0f/100.0f;
        Variables.WaterGainValue = 1.0f/100.0f;
        Variables.roundNumber = 1;
	}

}

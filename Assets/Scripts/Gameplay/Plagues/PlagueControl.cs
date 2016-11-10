using UnityEngine;
using System.Collections;

public class PlagueControl : MonoBehaviour {

    private float time = 0.0f;
    private float startTime = 1.0f;
    private float duration = 20.0f;
    private float plagueTime;
    private BarControl Bar;

	void Start () {
        Bar = gameObject.GetComponent<BarControl>();
        ClearPlagues();
	}
    public void Initialize(string plague)
    {
        // === Poisoned Gas ==
        if (plague == "PG")
        {
            Variables.poisonedGas = true; //cialo plagi w skrypcie MControl
        }
        // === Poisoned Water ===
        if (plague == "PW")
        {
            Variables.poisonedWater = true; // skrypt WaterButton
        }
        // === Hunger ===
        if (plague == "H")
        {
            Variables.hunger = true;
            Bar.difference = Bar.difference * 2;
        }
        // === Fullness ===
        if (plague == "Full")
        {
            Variables.full = true;
            Bar.difference = Bar.difference * (-2);
        }
    }

    void Update()
    {
        if (Variables.mode == "normal")
        {
            MaintainPlague();
        }
    }
    private void MaintainPlague()
    {
        if (Variables.poisonedGas || Variables.poisonedWater || Variables.hunger || Variables.full)
        {
            plagueTime += Time.deltaTime;
            if (plagueTime > duration)
            {
                ClearPlagues();
            }
        }
        else
        {
            time += Time.deltaTime;
        }

        if (time > startTime)
        {
            //losujemy plage
            //Initialize("PW");
        }
    }
    public void ClearPlagues()
    {
        Debug.Log("Plague Cleared");
        Variables.poisonedGas = false;
        Variables.poisonedWater = false;
        Variables.hunger = false;
        Variables.full = false;
        time = 0.0f;
        plagueTime = 0.0f;
        Bar.SetDifferential();
    }

}

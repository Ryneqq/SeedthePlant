using UnityEngine;
using System.Collections;

public class PlagueControl : MonoBehaviour {

    private float time = 0.0f;
    private float startTime = 5.0f;
    private float duration = 20.0f;
    private BarControl Bar;

	void Start () {
        ClearPlagues();
        Bar = gameObject.GetComponent<BarControl>();
	}
    public void Initialize(string plague)
    {
        // === Poisoned Gas ==
        if (plague == "PG")
        {
            Variables.poisonedGas = true;
        }
        // === Poisoned Water ===
        if (plague == "PW")
        {
            Variables.poisonedWater = true;
        }
        // === Hunger ===
        if (plague == "H")
        {
            Variables.hunger = true;
        }
        // === Fullness ===
        if (plague == "Full")
        {
            Variables.full = true;
        }
    }

    void Update()
    {
        MaintainPlague();
    }
    private void MaintainPlague()
    {
        if (Variables.poisonedGas || Variables.poisonedWater || Variables.hunger || Variables.full)
            Variables.plagueTime += Time.deltaTime; // czy trzymanie zmiennej czasowej w variables jest sensowne?
        else
        {
            time += Time.deltaTime;
        }
        if (Variables.plagueTime > duration)
        {
            ClearPlagues();
            Variables.plagueTime = 0.0f;
        }
        if (time > startTime)
        {
            //losujemy plage
            time = 0.0f;
        }
    }
    public void ClearPlagues()
    {
        Variables.poisonedGas = false;
        Variables.poisonedWater = false;
        Variables.hunger = false;
        Variables.full = false;
    }

}

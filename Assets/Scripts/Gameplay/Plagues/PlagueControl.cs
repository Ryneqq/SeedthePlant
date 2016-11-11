using UnityEngine;
using System.Collections;

public class PlagueControl : MonoBehaviour {

    private float time = 0.0f;
    private float startTime;
    private float duration;
    private float plagueTime;
    private BarControl Bar;

	void Start () {
        Bar = gameObject.GetComponent<BarControl>();
        ClearPlagues();
        startTime = Random.Range(10.0f, 15.0f);
        duration = Random.Range(20.0f, 30.0f);
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
        if (Variables.mode == "normal" && !Variables.pause)
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
            if (time > startTime)
            {
                RandomPlague();
            }
        }
    }
    private void RandomPlague()
    {
        startTime = Random.Range(10.0f, 20.0f);
        duration = Random.Range(20.0f, 30.0f);
        if (Variables.roundNumber < 5)
        {
            int plague = Random.Range(1, 5);
            if (plague == 1)
            {
                Initialize("PG");
                return;
            }
            else if (plague == 2)
            {
                Initialize("PW");
                return;
            }
            else if (plague == 3)
            {
                Initialize("H");
                return;
            }
            else if (plague == 4)
            {
                Initialize("Full");
                return;
            }
        }
        else if(Variables.roundNumber < 10)
        {
            int plague = Random.Range(1, 4);
            if (plague == 1)
            {
                Initialize("PG");
                Initialize("PW"); 
                return;
            }
            else if (plague == 2)
            {
                Initialize("PG");
                Initialize("H");
                return;
            }
            else if (plague == 3)
            {
                Initialize("PG");
                Initialize("Full");
                return;
            }
        }
        else
        {
            int plague = Random.Range(1, 3);
            if (plague == 1)
            {
                Initialize("PG");
                Initialize("PW");
                Initialize("H");
                return;
            }
            else if (plague == 2)
            {
                Initialize("PG");
                Initialize("PW");
                Initialize("Full");
                return;
            }
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

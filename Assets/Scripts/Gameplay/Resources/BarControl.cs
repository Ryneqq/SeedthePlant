using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <BarControl>
/// Skrypt odpowiada za ustawianie barow.
/// </BarControl>
public class BarControl : MonoBehaviour {
    //Bars managment
    private float StartValue = 40.0f;
    public Image O2Bar;
    private float O2Value;
    public Image CO2Bar;
    private float CO2Value;
    public Image SunBar;
    private float SunValue;
    public Image WaterBar;
    private float WaterValue;
    private float dif = -0.05f; //prywatna zmienna - zapamietana w niej jest pierwsza wartosc differential.
    public float difference;
    //Photo checkin
    private bool O2photo;
    private bool CO2photo;
    private bool Sunphoto;
    private bool Waterphoto;
    private float tTreshold = 1.0f; //max value for photo
    private float lTreshold = 0.5f; //min value for photo

	void Start ()
    {
        // Setting Bars
        SetO2(StartValue); SetCO2(StartValue);
        SetSun(StartValue); SetWater(StartValue);
        // Setting first difference value
        dif = dif / 100.0f;
        SetDifferential();
        // Setting photo bools
        O2photo = false; CO2photo = false;
        Sunphoto = false; Waterphoto = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Variables.mode == "normal" && !Variables.pause)
        {
            O2BarControl();
            CO2BarControl();
            SunBarControl();
            WaterBarControl();
            CheckForPhoto();
        }
    }
    private void CheckForPhoto ()
    {
        if (Variables.mode == "normal" && O2photo && CO2photo && Sunphoto && Waterphoto)
        {
            //rozpocznij photosynteze
            Variables.mode = "photo";

            SetO2(StartValue); SetCO2(StartValue);
            SetSun(StartValue); SetWater(StartValue);
            SetDifferential();
        }
    }
    // * * * * * O2 * * * * *
    private void O2BarControl ()
    {
        O2Value += difference;
        if (O2Value >= 1.0f)
            O2Value = 1.0f;
        if (O2Value <= 0.0f)
        {
            O2Value = 0.0f;
            GetComponent<GameOver>().almostOver = true;
        }
        O2Bar.GetComponent<Image> ().transform.localScale = new Vector3(O2Value, 1, 1);

        if (!O2photo && O2Value >= lTreshold && O2Value <= tTreshold)
            O2photo = true;
        else if (O2Value < lTreshold || O2Value > tTreshold)
            O2photo = false;
    }
    public void GainO2 ()
    {
        O2Value += Variables.O2GainValue;
        if (O2Value >= 1.0f)
            O2Value = 1.0f;
        O2Bar.GetComponent<Image> ().transform.localScale = new Vector3(O2Value, 1, 1);
    }
    public void GainO2(float value)
    {
        float tempValue = O2Value + value;
        SetO2(tempValue*100.0f);
    }
    public void SetO2(float value)
    {
        value = value / 100.0f;
        O2Value = value;
        if (O2Value >= 1.0f)
            O2Value = 1.0f;
        if (O2Value <= 0.0f)
            O2Value = 0.0f;
        O2Bar.GetComponent<Image>().transform.localScale = new Vector3(O2Value, 1, 1);
    }
    // * * * * * CO2 * * * * *
    private void CO2BarControl()
    {
        CO2Value += difference;
        if (CO2Value >= 1.0f)
            CO2Value = 1.0f;
        if (CO2Value <= 0.0f)
        {
            CO2Value = 0.0f;
            GetComponent<GameOver>().almostOver = true;
        }
        CO2Bar.GetComponent<Image>().transform.localScale = new Vector3(CO2Value, 1, 1);

        if (!CO2photo && CO2Value >= lTreshold && CO2Value <= tTreshold)
            CO2photo = true;
        else if (CO2Value < lTreshold || CO2Value > tTreshold)
            CO2photo = false;
    }
    public void GainCO2()
    {
        CO2Value += Variables.CO2GainValue;
        if (CO2Value >= 1.0f)
            CO2Value = 1.0f;
        CO2Bar.GetComponent<Image>().transform.localScale = new Vector3(CO2Value, 1, 1);
    }
    public void GainCO2(float value)
    {
        float tempValue = CO2Value + value;
        SetCO2(tempValue * 100.0f);
    }
    public void SetCO2(float Value)
    {
        Value = Value / 100.0f;
        CO2Value = Value;
        if (CO2Value >= 1.0f)
            CO2Value = 1.0f;
        if (CO2Value <= 0.0f)
            CO2Value = 0.0f;
        CO2Bar.GetComponent<Image>().transform.localScale = new Vector3(CO2Value, 1, 1);
    }
    // * * * * * Sun * * * * *
    private void SunBarControl()
    {
        SunValue += difference;
        if (SunValue >= 1.0f)
            SunValue = 1.0f;
        if (SunValue <= 0.0f)
        {
            SunValue = 0.0f;
            GetComponent<GameOver>().almostOver = true;
        }
        SunBar.GetComponent<Image>().transform.localScale = new Vector3(SunValue, 1, 1);

        if (!Sunphoto && SunValue >= lTreshold && SunValue <= tTreshold)
            Sunphoto = true;
        else if (SunValue < lTreshold || SunValue > tTreshold)
            Sunphoto = false;
    }
    public void GainSun()
    {
        SunValue += Variables.SunGainValue;
        if (SunValue >= 1.0f)
            SunValue = 1.0f;
        SunBar.GetComponent<Image>().transform.localScale = new Vector3(SunValue, 1, 1);

    }
    public void GainSun(float value)
    {
        float tempValue = SunValue + value;
        SetSun(tempValue * 100.0f);

    }
    public void SetSun(float Value)
    {
        Value = Value / 100.0f;
        SunValue = Value;
        if (SunValue >= 1.0f)
            SunValue = 1.0f;
        if (SunValue <= 0.0f)
            SunValue = 0.0f;
        SunBar.GetComponent<Image>().transform.localScale = new Vector3(SunValue, 1, 1);
    }
    // * * * * * Water * * * * *
    private void WaterBarControl()
    {
        WaterValue += difference;
        if (WaterValue >= 1.0f)
            WaterValue = 1.0f;
        if (WaterValue <= 0.0f)
        {
            WaterValue = 0.0f;
            GetComponent<GameOver>().almostOver = true;
        }
        WaterBar.GetComponent<Image>().transform.localScale = new Vector3(WaterValue, 1, 1);

        if (!Waterphoto && WaterValue >= lTreshold && WaterValue <= tTreshold)
            Waterphoto = true;
        else if (WaterValue < lTreshold || WaterValue > tTreshold)
            Waterphoto = false;
    }
    public void GainWater()
    {
        WaterValue += Variables.WaterGainValue;
        if (WaterValue >= 1.0f)
            WaterValue = 1.0f;
        WaterBar.GetComponent<Image>().transform.localScale = new Vector3(WaterValue, 1, 1);

    }
    public void SetWater(float Value)
    {
        Value = Value / 100.0f;
        WaterValue = Value;
        if (WaterValue >= 1.0f)
            WaterValue = 1.0f;
        if (WaterValue <= 0.0f)
            WaterValue = 0.0f;
        WaterBar.GetComponent<Image>().transform.localScale = new Vector3(WaterValue, 1, 1);
    }
    // * * * * *  * * * * *
    public void ClearBars()
    {
        O2Value = 0.0f;
        O2Bar.GetComponent<Image>().transform.localScale = new Vector3(O2Value, 1, 1);
        CO2Value = 0.0f;
        CO2Bar.GetComponent<Image>().transform.localScale = new Vector3(CO2Value, 1, 1);
        SunValue = 0.0f;
        SunBar.GetComponent<Image>().transform.localScale = new Vector3(SunValue, 1, 1);
        WaterValue = 0.0f;
        WaterBar.GetComponent<Image>().transform.localScale = new Vector3(WaterValue, 1, 1);
    }
    public bool ReValues() //return information bout that Values are higher than zero or not
    {
        if (O2Value > 0.0f && CO2Value > 0.0f && SunValue > 0.0f && WaterValue > 0.0f)
        {
            return true;
        }
        return false;
    }
    public void SetDifferential()
    {
        // różnica o ktora pomniejszaja sie bary co klatke - zalezy od zmiennej roundNumber 
        //difference = dif * (1 + (Variables.roundNumber - 1) / Variables.roundNumber);
        difference = 0.0f;
    }
}

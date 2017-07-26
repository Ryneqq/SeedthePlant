using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SunControl : MonoBehaviour {
    private BarControl Bar;
    private Button TurnOn;

    public void Clicked() //obiekt został naklikniety
    {
        Bar.GainSun();
        Destroy(this.gameObject);
        --Variables.SunCounter;
    }
    void Start()
    {
        Bar = GameObject.Find("Main Camera").GetComponent<BarControl>();
        TurnOn = GetComponent<Button>();
    }
    void Update()
    {
        if (!Variables.pause && TurnOn.enabled == false)
            TurnOn.enabled = true;
        if (!Variables.pause)
        {
            if (!gameObject.GetComponent<Image>().enabled) // wylaczany zostaje w animacji
            {
                Destroy(this.gameObject); // obiekt przekroczyl dlugosc swojego zycia
                --Variables.SunCounter;
            }
        }
        else //pauza wlaczona
        {
            TurnOn.enabled = false;
        }
    }
}

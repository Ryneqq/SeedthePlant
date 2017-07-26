using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MContol : MonoBehaviour {

    private float time = 0.0f;
    private float V,Fx, Fy, RFx, T;
    private BarControl Bar;
    private Button TurnOn;

    public void Clicked() //obiekt został naklikniety
    {

        if (gameObject.CompareTag("O2"))
        {
            Bar.GainO2();
            Destroy(this.gameObject);
            --Variables.O2Counter;
        }
        if (gameObject.CompareTag("CO2"))
        {
            Bar.GainCO2();
            Destroy(this.gameObject);
            --Variables.CO2Counter;
        }
        if (gameObject.CompareTag("PG"))
        {
            //Wyzeruj Bary
            Bar.ClearBars();
            Destroy(this.gameObject);
            --Variables.pGasCounter;
        }
    }

    public void Initialize()
    {
        if (Variables.Side == "Left")
        {
            V = Random.Range(15.0f, 30.0f);
            Fx = Random.Range(1.0f, 2.0f);
            RFx = Random.Range(0.1f, 0.2f);
        }
        if (Variables.Side == "Right")
        {
            V = Random.Range(-15.0f, -30.0f);
            Fx = Random.Range(-1.0f, -2.0f);
            RFx = Random.Range(-0.1f, -0.2f);
        }

        Fy = Random.Range(-0.5f, 0.5f);
        T = Random.Range(-100.0f, 100.0f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(V, 0.0f);
        GetComponent<ConstantForce2D>().force = new Vector2(Fx, Fy);
        GetComponent<ConstantForce2D>().relativeForce = new Vector2(RFx, 0.0f);
        GetComponent<ConstantForce2D>().torque = T;
        //gameObject.GetComponent<PolygonCollider2D>().enabled = true;
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
            time += Time.deltaTime;
            if (time >= 1.0f)
            {
                gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            }
            if (!gameObject.GetComponent<Image>().enabled)
            {
                DestroyGases();
            }
        }
        else
        {
            //DestroyGases();
            TurnOn.enabled = false;
        }
    }
    
    private void DestroyGases()
    {
        if (gameObject.CompareTag("O2"))
        {
            --Variables.O2Counter;
        }
        if (gameObject.CompareTag("CO2"))
        {
            --Variables.CO2Counter;
        }
        if (gameObject.CompareTag("PG"))
        {
            --Variables.pGasCounter;
        }

        Destroy(this.gameObject);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateRes : MonoBehaviour {
    private float time = 0.0f;
    private float CreationTime = 2.0f;

    private Vector2 ResPoint;
    private Vector2 MaxGasCoo;
    private Vector2 MinGasCoo;
    private int Side;

    private Button temp;
    public Button O2;
    public Button CO2;
    public Button PG;
    public Button Sun;
    public Canvas GameCanvas;

    void Start ()
    {
        //Koordynacje dla spawnowania gazu
        MinGasCoo.x = -1040.0f;
        MaxGasCoo.x = 1040.0f;
        MinGasCoo.y = -300.0f;
        MaxGasCoo.y = 300.0f;
        // Strona początkowa
        Variables.Side = "Left";
        //Zainicjowanie liczników
        Variables.O2Counter = 0;
        Variables.CO2Counter = 0;
        Variables.pGasCounter = 0;
        Variables.SunCounter = 0;
    }
    void Update()
    {
        if (!Variables.pause && Variables.mode == "normal")
        {
            time += Time.deltaTime;
            if (time >= CreationTime)
            {
            // Powoduje to naprzemienne wybieranie strony spawnowania cząsteczek gazu
                if (Variables.Side == "Left")
                {
                    ResPoint.x = MinGasCoo.x;
                    ResPoint.y = Random.Range(MinGasCoo.y, MaxGasCoo.y);
                }
                if (Variables.Side == "Right")
                {
                    ResPoint.x = MaxGasCoo.x;
                    ResPoint.y = Random.Range(MinGasCoo.y, MaxGasCoo.y);
                }

                // === wywołanie funkcji spawnujących ===

                if (Variables.O2Counter < 3)
                {
                    CreateO2(ResPoint);
                }
                if (Variables.CO2Counter < 3)
                {
                    CreateCO2(ResPoint);
                }
                // === Poisoned Gas ===
                if (Variables.poisonedGas && Variables.pGasCounter < 6)
                {
                    CreatePG(ResPoint);
                }
                // ===    PGend     ===

                if (Variables.SunCounter < 3)
                {
                    ResPoint.x = Random.Range(-300.0f, 300.0f);
                    ResPoint.y = Random.Range(-300.0f, 300.0f);
                    CreateSun(ResPoint);
                }

                CreationTime = Random.Range(2.0f, 3.0f);
                time = 0.0f;
                
                // Strony spawnowania są naprzemienne
                if (Variables.Side == "Right")
                    Variables.Side = "Left";
                else
                    Variables.Side = "Right";
            }
        }
    }
    private void CreateO2(Vector2 Respawn)
    {
        temp = (Button)Instantiate(O2, Respawn, Quaternion.identity);
        temp.transform.SetParent(GameCanvas.transform, false);
        temp.GetComponent<MContol>().Initialize();
        ++Variables.O2Counter;
    }
    private void CreateCO2(Vector2 Respawn)
    {
        temp = (Button)Instantiate(CO2, new Vector2(Respawn.x, -Respawn.y), Quaternion.identity);
        temp.transform.SetParent(GameCanvas.transform, false);
        temp.GetComponent<MContol>().Initialize();
        ++Variables.CO2Counter;
    }
    private void CreatePG(Vector2 Respawn)
    {
        temp = (Button)Instantiate(PG, new Vector2(Respawn.x, Respawn.y/2), Quaternion.identity);
        temp.transform.SetParent(GameCanvas.transform, false);
        temp.GetComponent<MContol>().Initialize();
        ++Variables.pGasCounter;
    }
    private void CreateSun(Vector2 Respawn)
    {
        temp = (Button)Instantiate(Sun, new Vector2(Respawn.x, Respawn.y), Quaternion.identity);
        temp.transform.SetParent(GameCanvas.transform, false);
        ++Variables.SunCounter;
    }
}

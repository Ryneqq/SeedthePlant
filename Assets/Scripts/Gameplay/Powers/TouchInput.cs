using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {
    public bool power;
    private bool charge = false;
    private bool once = false;
    private float time = 0.0f;
    private float timeonce = 0.0f;
    private float onceOff = 0.5f;
    private float turnOff = 1.0f;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touches;

    private LogControl debugLog;
    void Start () {
        power = false;
        debugLog = Camera.main.GetComponent<LogControl>();

    }
	
	void Update () {
        //Zostawiam to jako szkielet multitoucha - duuuuzzoooo obliczen
        /*if (Input.touchCount > 0)
        {
            touches = new GameObject[touchList.Count];
            touchList.CopyTo(touches);
            touchList.Clear();
            foreach(GameObject touch in touches)
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            }
        }*/
        if (Input.GetMouseButtonDown(0)) //mouse
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null) //jezeli w cos trafimy
            {
                if (hit.collider.CompareTag("Pot"))
                {
                    if (!charge)
                        charge = true;
                    else
                        power = true;
                }
            }
        }
        /*else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !once)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null) //jezeli w cos trafimy
            {
                if (hit.collider.CompareTag("Pot"))
                {
                    if (!charge && !once)
                    {
                        charge = true;
                        debugLog.Set("Charged");
                    }
                    else if(!once)
                    {
                        power = true;
                        debugLog.Set("Superpower bithes!");
                    }
                }
            }
            once = true;
        }
        if (once)
        {
            timeonce += Time.deltaTime;
            if (timeonce > onceOff)
            {
                once = false;
                timeonce = 0.0f;
            }
        }
        */
        if (charge)
        {
            time += Time.deltaTime;
            if (time > turnOff)
            {
                charge = false;
                time = 0.0f;
            }
        }
        else if (power)
        {
            Debug.Log("Superumiejetnosc bitches");
            BarControl bar = Camera.main.GetComponent<BarControl>();
            bar.ClearBars();
            power = false;
        }
	}
}

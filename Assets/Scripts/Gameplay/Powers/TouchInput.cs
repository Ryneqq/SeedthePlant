using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {
    public bool power;
    private bool charge = false;
    private float time = 0.0f;
    private float turnOff = 1.0f;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touches;
  
    void Start () {
        power = false;
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
                //Debug.Log("trafilem cos ale nie wiem czy zyje o.O");
                //Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("Pot"))
                {
                    if (!charge)
                        charge = true;
                    else
                        power = true;
                }
            }
        }
        //else if(Input.GetTouch(0))
        if (charge)
        {
            time += Time.deltaTime;
            if (time > turnOff)
            {
                charge = false;
            }
        }
        else if (power)
        {
            Debug.Log("Superumiejetnosc bitches");
        }
	}
}

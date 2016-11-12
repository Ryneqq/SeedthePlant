using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    private float time;
    public float deathTime;
    public bool almostOver;
    public bool gameOver;
    private BarControl bar;

	void Start () {
        almostOver = false;
        gameOver = false;

        deathTime = 3.0f;
        bar = GetComponent<BarControl>();
	}
	void Update () {
        if (!Variables.pause && almostOver)
        {
            time += Time.deltaTime;
            if(deathTime < time)
            {
                ShittyEnd();
            }
            else
            {
                NotShittyAtAll();
            }
        }
        if(!Variables.pause && gameOver)
        {
            ShittyEnd();
        }
	
	}
    private void ShittyEnd()
    {
        Application.LoadLevel("Gameplay");
    }
    private void NotShittyAtAll()
    {
            if (bar.ReValues())
            {
                almostOver = false;
            }
    }
}

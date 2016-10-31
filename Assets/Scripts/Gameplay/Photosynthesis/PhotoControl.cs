using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhotoControl : MonoBehaviour {

    private bool triggered = false;
    public Image photoBar;
    public Canvas photoCanvas;
    private float reactionTime = 10.0f;
    private float time = 0.0f;
    private float timeLeft;
    private float delta = 0.95f;
    private bool reactionFailed = false;

	void Update ()
    {
	    if (!triggered && Variables.mode == "photo")
        {
            //startPhoto();
            Debug.Log("wchodze");
            triggered = true; 
        }
        if(Variables.mode == "photo")
        {
            photoBarControl();
        }
        if(triggered && reactionFailed)
        {
            Debug.Log("wychodze");
            endPhoto();
        }
	}
    private void startPhoto()
    {
        photoCanvas.GetComponent<Canvas>().enabled = true;
    }
    private void endPhoto()
    {
        photoCanvas.GetComponent<Canvas>().enabled = false;
        Variables.mode = "normal";
        triggered = false;
        reactionFailed = false;
        ++Variables.roundNumber; // numer rundy
    }
    private void photoBarControl()
    {
        time -= Time.deltaTime;
        if (time < 0.0f)
        {
            reactionFailed = true;
            return;
        }
        else
        {
            timeLeft = time / reactionTime;
        }
        //photoBar.GetComponent<Image>().transform.localScale = new Vector3(timeLeft, 1, 1);
    }
    public void ReactionTime()
    {
        time = reactionTime;
        reactionTime = time * delta;
    }
}

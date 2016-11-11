using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

public void Clicked()
    {
        if (Variables.pause)
            Variables.pause = false;
        else if (!Variables.pause)
            Variables.pause = true;
        
    }
}

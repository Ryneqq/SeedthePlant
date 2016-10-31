using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{
    public void Drag()
    {   // Dotykowy ekran
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 objectPosition = gameObject.GetComponent<RectTransform>().position;
            Vector2 touchPosition = Input.GetTouch(0).position;
            gameObject.GetComponent<RectTransform>().position = new Vector2(touchPosition.x, touchPosition.y);
        }
        else // myszka
        {
            Vector2 objectPosition = gameObject.GetComponent<RectTransform>().position;
            Vector2 touchPosition = Input.mousePosition;
            gameObject.GetComponent<RectTransform>().position = new Vector2(touchPosition.x, touchPosition.y);
        }
    }
    public void Drop()
    {

    }
}
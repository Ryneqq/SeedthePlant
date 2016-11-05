using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <SwipeDetector>
/// Obiekt znajduje sie na nasionku,odpowiada za przesowanie obiektu - drag and drop, funkcje w nim zawarte korzystaja z event triggera
/// OUT: SeedControl - seed zostal upuszczony podczas kolizji, zajmij sie tym.
/// IN:  Input - pozycja dotyku ewentualnie myszki.
///      Taker - jest wykryta kolizja, nazwa collider'a
///      Destroyer - patrz tu ^
/// </SwipeDetector>
public class SwipeDetector : MonoBehaviour
{
    public bool colliding = false;
    public string whichCollider;

    // Funkcja odpowiedzialna za przesowanie obiektu
    // Uzywa komponentu Event trigger: Drag.
    public void Drag()
    {   // Dotykowy ekran
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchPosition = Input.GetTouch(0).position; //zapamietuje pozycje dotyku
            gameObject.GetComponent<RectTransform>().position = new Vector2(touchPosition.x, touchPosition.y);// przesuwa obiekt w to miejsce
        }
        else // myszka
        {
            Vector2 touchPosition = Input.mousePosition;
            gameObject.GetComponent<RectTransform>().position = new Vector2(touchPosition.x, touchPosition.y);
        }
    }
    // Funkcja wywolywana na koniec ciagniecia obiektu
    // Wywolywana komponentem Event trigger: End Drag.
    public void Drop()
    {
        if (colliding)
        {
            gameObject.GetComponent<SeedControl>().ManageSeed(whichCollider);
        }
    }
}
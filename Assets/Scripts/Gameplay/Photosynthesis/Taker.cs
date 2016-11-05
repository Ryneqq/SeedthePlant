using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <Taker>
/// Zandjuje się na objekcie 'Taker'. Wykrywa kolizje z obiektem 'Taker'.
/// Detekcja kolizji polega na zmianie skali obiektu. Gdy wykryje kolizje wysyla wiadomosci o tym evencie.
/// OUT: SwipeDetector - informacje o wystapieniu kolizji.
/// IN:  Rigidbody2D & BoxCollider2D - wystapila kolizja.
/// </Taker>
public class Taker : MonoBehaviour {
    private Transform scale;
    private SwipeDetector swipeSeed;
    void Start()
    {
        scale = gameObject.GetComponent<Image>().transform;
    }
     void OnCollisionEnter2D(Collision2D col) // wykrywam kolizje
    {
        scale.localScale = new Vector2(1.2f, 1.2f); // powiekszam sie
        swipeSeed = col.gameObject.GetComponent<SwipeDetector>(); // biore swipe detectora by wyslac mu wiadomosc o aktualnym stanie kolizji.
    }                                                             // na podstawie wyslanych mu informacji sprawdzam gdzie zostal dropniety seed.
    void OnCollisionStay2D(Collision2D col) //kolizja trwa
    {
        if (scale.localScale.x < 1.1f && scale.localScale.y < 1.1f) // to zapobiega dziwnym przerwaniom towarzyszacym wykrywaniu kolizji
            scale.localScale = new Vector2(1.2f, 1.2f); // by caly czas zachowac skale ktora sugeruje ze kolizja jest wykrywana
        if (!swipeSeed.colliding)   // informacja wysylana SwipeDetectorowi ze kolizja istnieje
            swipeSeed.colliding = true;
        if (swipeSeed.whichCollider != "Taker") // i nazwe obiektu z ktorym koliduje.
            swipeSeed.whichCollider = "Taker";
    }
    void OnCollisionExit2D(Collision2D col) // kolizja zakonczona.
    {   // wracamy do ustawien fabrycznych.
        scale.localScale = new Vector2(1.0f, 1.0f);
        swipeSeed.colliding = false;
        swipeSeed.whichCollider = "none";
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <SeedControl>
/// Obiekt znajduje sie na nasionku, opisuje jego zachowanie oraz zapamietuje liczbe zdobytych nasionek.
/// OUT: CreateSeeds - zniszczylem seeda.
///      SwipeDetector - wyczysc zmienne przechowujace informacje o kolizji.
///      Taker - obiekt zniszczony, brak kolizji, zmien skale na normalna.
///      Destroyer - to samo ^
/// IN:  SwipeDetector - seed został upuszczony podczas kolizji. 
/// 
/// skrypt korzysta ze zmiennych globalnych:  Variables.
/// </SeedControl>
public class SeedControl : MonoBehaviour {
    private CreateSeeds seed;
    private int saveNormal;
    private int saveAncient;

	void Start () { //zapamietuje ilosc nasionek zdobytych przed gra.
        seed = GameObject.Find("Main Camera").GetComponent<CreateSeeds>();
        saveNormal = PlayerPrefs.GetInt("noNormal");
        saveAncient = PlayerPrefs.GetInt("noAncient");
	}
	
    public void ManageSeed(string collider)
    {
        if (collider == "Taker") // sprawdzamy w jaki collider zosstal wrzucony seed (taker od take, chyba jasne :D)
        {
            EndCollision(collider); // konczymy kolizje
            if (gameObject.CompareTag("Normal")) // jezeli byl to normalny
            {
                NormalCounter(); // to dolicz go do  pozostalych
            }
            else if (gameObject.CompareTag("Ancient"))  // bla bla bla i tak dalej
            {
                AncientCounter();
            }
            else if (gameObject.CompareTag("Rotten")) //po prostu konczymy fotosynteze
            {
                GameObject.Find("Main Camera").GetComponent<PhotoControl>().EndPhoto();
            }
            else if (gameObject.CompareTag("Plagued")) //niszczymy dotychczasowe zbiory z tej gry i konczymy photo.
            { 
                DestroyCrops();
                GameObject.Find("Main Camera").GetComponent<PhotoControl>().EndPhoto();
            }
            // Nasionko zostalo wziete!
            Destroy(this.gameObject);
            seed.isDestroyed(); // seed zostal zniszczony, mozna stworzyc nowy.
        }
        else if (collider == "Destroyer") //to co wyzej ^
        {
            EndCollision(collider);
            Destroy(this.gameObject);
            seed.isDestroyed();
        }
    }

    private void NormalCounter()
    {
        ++Variables.noNormal; // wartosc uzyskana podczas gry
        ++saveNormal; // posiadana wartosc przed gra
        PlayerPrefs.SetInt("savedNormal", saveNormal); //wprowadzenie stanu seedow
        PlayerPrefs.Save(); //zapisanie wartosci w osobnym pliku
                            // wykonuje takie dzialanie po kazdym wzietym nasionku
                            // robie to by w razie gdyby gracz np. zdecydowal sie wyjsc w trakcie gry
                            // to nie straci tego co juz zebral.
    }

    private void AncientCounter() // to samo co wyzej ^
    {
        ++Variables.noAncient;
        ++saveAncient;
        PlayerPrefs.SetInt("savedAncient", saveAncient);
        PlayerPrefs.Save();
    }

    private void DestroyCrops()
    {   // no i tu mamy troche liczenia ze wzgledu na to o czym pisalem do gory, ze zapisuje ilosc po kazdym wzietym seedzie.
        // zapisana ilosc od ktorej odejmuje ilosc zdobyta podczas gry i zapisac spowrotem :)
        saveNormal = saveNormal - Variables.noNormal;
        saveAncient = saveAncient - Variables.noAncient;
        PlayerPrefs.SetInt("savedNormal", saveNormal);
        PlayerPrefs.SetInt("savedAncient", saveAncient);
        PlayerPrefs.Save();
        Variables.noNormal = 0;
        Variables.noAncient = 0;
    }

    // Funkcje wykrywajace kolizje znajduja sie w skryptach: Taker i Destroyer

    // OnCollisionExit2D (wykrywajacy koniec kolizji) nie dziala w przypadku gdy obiekt kolidujacy
    // zostaje zniszczony, a OnCollisionStay2D(gdy kolizja trwa) nie zostaje wywolany bo nie ma juz obiektu kolidujacego
    // wiec w ramach zastepstwa: to daje 'efekt' wyjscia z kolizji, ktorej już nie ma.
    private void EndCollision(string collider)
    {
        SwipeDetector swipedObject = gameObject.GetComponent<SwipeDetector>();
        if (collider == "Taker")
        {
            GameObject.Find(collider).GetComponent<Transform>().localScale = new Vector2(1.0f, 1.0f);
            swipedObject.colliding = false;
            swipedObject.whichCollider = "none";
        }
        else if (collider == "Destroyer")
        {
            Debug.Log("DUPADADADADA");
            GameObject.Find(collider).GetComponent<Transform>().localScale = new Vector2(1.0f, 1.0f);
            swipedObject.colliding = false;
            swipedObject.whichCollider = "none";
        }
    }
}

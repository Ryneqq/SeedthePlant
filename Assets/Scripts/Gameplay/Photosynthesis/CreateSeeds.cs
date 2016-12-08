using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <CreateSeeds>
/// Komponent znajduje sie na kamerze, odpowiedzialny za spawnowanie seedow
/// OUT: PhotoControl - zmniejsz czas reakcji
/// IN:  SeedControl - zespawnuj nowego Seeda.
/// 
/// skrypt korzysta ze zmiennych globalnych:  Variables.
/// </CreateSeeds>
public class CreateSeeds : MonoBehaviour {
    //creating seeds
    //private Image temp;
    public Image Ancient;
    public Image Normal;
    public Image Rotten;
    public Image Plagued;
    public Canvas photoCanvas;

    public string seedTag;

    //=== probability ===
    private float probAncient = 1.0f; //ancient
    private float probPlagued = 4.0f; //plagued
    private float probRotten = 35.0f; //rotten
    // Rest of the range is for normal seed
    private int noSeeds = 1;
    private float probability;
    //===================

    private float time = 0.0f;
    private bool destroyed; //sluzy do sprawdzania czy Seed zostal zniszczony

	// Na poczatku nasionko zostalo zniszczone
	void Start () {
        isDestroyed();
	}
	
	// w update'cie sprawdzamy czy sa odpowiednie warunki do wykonywania skryptu
	void Update ()
    {
        if (Variables.mode == "photo" && destroyed)
        {
            string whichSeed = RandomSeed();
            CreateSeed(whichSeed);
            gameObject.GetComponent<PhotoControl>().ReactionTime(); //wywolanie obliczenia czasu reakcji
            destroyed = false; // nasionko nie jest zniszczone, dopiero co je stworzylismy.
        }
	}
    // Funkcja losujaca nasionko
    // zwraca string z nazwa nasionka
    private string RandomSeed()
    {
        // Oblicznae tu prawdopodobienstwo jest funkcja dwoch zmiennych - zalezy od numeru rundy i liczby seedow zeswpawnowanych w danej rundzie
        probability = Random.Range(0.0f, 100.0f);
        float probabilityAncient = probAncient + ((float)(Variables.roundNumber + noSeeds - 2))/4;
        float probabilityPlagued = probPlagued + ((float)(2 * (Variables.roundNumber + noSeeds - 2)))/4;
        float probabilityRotten = probRotten + ((float)(Variables.roundNumber + noSeeds - 2))/4;

        if (probability <= probabilityAncient)
        {
            return "ancient";
        }
        else if (probability <= probabilityPlagued && probability > probabilityAncient)
        {
            return "plagued";
        }
        else if (probability <= probabilityRotten && probability > probabilityPlagued)
        {
            return "rotten";
        }
        else if (probability > probabilityRotten)
        {
            return "normal";
        }
        return "null";
    }
    // funkcja spawnuje seedy na podstawie otrzymanego stringa
    private void CreateSeed(string Seed)
    {
        Image temp;
        if (Seed == "ancient")
        {
            temp = (Image)Instantiate(Ancient, new Vector2(0.0f,0.0f), Quaternion.identity);
            temp.transform.SetParent(photoCanvas.transform, false);
        }
        else if (Seed == "plagued")
        {
            temp = (Image)Instantiate(Plagued, new Vector2(0.0f, 0.0f), Quaternion.identity);
            temp.transform.SetParent(photoCanvas.transform, false);
        }
         else if (Seed == "rotten")
        {
            temp = (Image)Instantiate(Rotten, new Vector2(0.0f, 0.0f), Quaternion.identity);
            temp.transform.SetParent(photoCanvas.transform, false);
        }
        else// if (Seed == "normal")
        {
            temp = (Image)Instantiate(Normal, new Vector2(0.0f, 0.0f), Quaternion.identity);
            temp.transform.SetParent(photoCanvas.transform, false);
        }
        seedTag = temp.tag;
        ++noSeeds;
    }
    //funkcja ktora zmienia prywatnego boola - dla bezpieczenstwa.
    public void isDestroyed()
    {
        destroyed = true;
    }
}

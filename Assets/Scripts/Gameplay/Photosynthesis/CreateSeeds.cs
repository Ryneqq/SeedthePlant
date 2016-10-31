using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateSeeds : MonoBehaviour {
    //creating seeds
    private Image temp;
    public Image Ancient;
    public Image Normal;
    public Image Rotten;
    public Image Plagued;
    public Canvas photoCanvas;

    //=== probability ===
    private float probAncient = 1.0f; //ancient
    private float probPlagued = 4.0f; //plagued
    private float probRotten = 35.0f; //rotten
    // Rest of the range is for normal seed
    private int noSeeds = 1;
    private float probability;
    //===================

    private float time = 0.0f;
    private bool destroyed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        if (Variables.mode == "photo" && destroyed)// && czy zostalo zniszczone (zamiast time)
        {
            string whichSeed = RandomSeed();
            CreateSeed(whichSeed);
            destroyed = false;
        }
	}
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
        if (probability <= probabilityPlagued && probability > probabilityAncient)
        {
            return "plagued";
        }
        if (probability <= probabilityRotten && probability > probabilityPlagued)
        {
            return "rotten";
        }
        if (probability > probabilityRotten)
        {
            return "normal";
        }
        return "null";
    }
    private void CreateSeed(string Seed)
    {
        if (Seed == "ancient")
        {
            temp = (Image)Instantiate(Ancient, new Vector2(0.0f,0.0f), Quaternion.identity);
            temp.transform.SetParent(photoCanvas.transform, false);
        }
        if (Seed == "plagued")
        {
            temp = (Image)Instantiate(Plagued, new Vector2(0.0f, 0.0f), Quaternion.identity);
            temp.transform.SetParent(photoCanvas.transform, false);
        }
        if (Seed == "rotten")
        {
            temp = (Image)Instantiate(Rotten, new Vector2(0.0f, 0.0f), Quaternion.identity);
            temp.transform.SetParent(photoCanvas.transform, false);
        }
        if (Seed == "normal")
        {
            temp = (Image)Instantiate(Normal, new Vector2(0.0f, 0.0f), Quaternion.identity);
            temp.transform.SetParent(photoCanvas.transform, false);
        }
        ++noSeeds;
    }
    public void isDestroyed()
    {
        destroyed = true;
    }
}

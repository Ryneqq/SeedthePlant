﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <PhotoControl>
/// Komponent znajduje się na glownej kamerze, obsluguje fotosynteze, oblicza czas dany graczowi na reakcje oraz wyswietla go w postaci paska.
/// IN: BarControl - fotosynteza się zaczela
///     CreateSeeds - oblicz nowy czas reakcji
///     SeedControl - Zostaly wziete trujace nasionka, zakoncz fotosynteze;
/// 
/// skrypt korzysta ze zmiennych globalnych:  Variables.
/// </PhotoControl>
public class PhotoControl : MonoBehaviour {

    private bool triggered = false;
    public Image photoBar;
    public Canvas photoCanvas;
    private float reactionTime;
    private float time = 0.0f;
    private float timeLeft;
    private float delta = 0.95f;
    private bool reactionFailed = false;

    void Start()
    {
        photoCanvas.gameObject.SetActive(false);
    }
	void Update ()
    {   // bool triggered odpowiada za wlaczenie fotosyntezy i nie dopuszczenie by ten if odpalil sie wiecej niz raz na fotosynteze.
	    if (!triggered && Variables.mode == "photo")
        {
            StartPhoto();
            triggered = true; 
        }
        if(Variables.mode == "photo") // to wykonuje się cały czas gdy jest wlaczona fotosynteza
        {
            PhotoBarControl();
        }
        if(triggered && reactionFailed) // ten warunek sprawdza czy gracz nie spierdolil sprawy
        {
            EndPhoto();
        }
	}
    private void StartPhoto()
    {
        DestroyResources();
        gameObject.GetComponent<PlagueControl>().ClearPlagues(); // czyscimy plagi, zeby sie nie okazalo ze po zakonczeniu fotosyntezy pojawia sie plaga.
        photoCanvas.GetComponent<NumbersControl>().SetNumber(); // aktualizujemy wartosci seedow
        TurnCanvas("off");
        photoCanvas.gameObject.SetActive(true);
        reactionTime = 10.0f; // ustawiam wartosc startowa kazdej photosyntezy
        time = reactionTime;
    }
    // funkcja konczy fotosynteze
    public void EndPhoto()
    {
        Variables.mode = "normal";
        // === zniszcz nasionko ===
        Destroy(GameObject.FindGameObjectWithTag(GetComponent<CreateSeeds>().seedTag).gameObject);
        GetComponent<CreateSeeds>().isDestroyed();
        // ========================
        photoCanvas.gameObject.SetActive(false);
        TurnCanvas("on");
        triggered = false;
        reactionFailed = false;
        Variables.O2Counter = 0;
        Variables.CO2Counter = 0;
        Variables.pGasCounter = 0;
        ++Variables.roundNumber; // numer rundy
        // uruchom funkcje do resetowania superumiejetnosci
    }
    // funkcja obsluguje bar odliczajacy dany czas na reakcje gracza
    private void PhotoBarControl()
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
        photoBar.GetComponent<Image>().transform.localScale = new Vector3(timeLeft, 1, 1);
    }
    // prosta funkcja obliczajaca czas na reakcje ktory jest iloczynem poprzedniej wartosci czasu reakcji i zmiennej delta.
    public void ReactionTime()
    {
        reactionTime = reactionTime * delta;
        time = reactionTime;
    }
    public void DestroyResources()
    {
        // * * * * * Usuniecie wszystkich obiektow * * * * *
        GameObject[] O2list = GameObject.FindGameObjectsWithTag("O2"); // tworze liste obiektow z takim tagiem
        foreach (GameObject O2 in O2list) // w petli dostaje sie do kadego elementu z listy
        {
            Destroy(O2.gameObject); // i go niszcze
        }
        GameObject[] CO2list = GameObject.FindGameObjectsWithTag("CO2");
        foreach (GameObject CO2 in CO2list)
        {
            Destroy(CO2.gameObject);
        }
        GameObject[] PGlist = GameObject.FindGameObjectsWithTag("PG");
        foreach (GameObject posionedGas in PGlist)
        {
            Destroy(posionedGas.gameObject);
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    }
    public void TurnCanvas(string what)
    {
        GameObject[] Canvaslist = GameObject.FindGameObjectsWithTag("GCanvas");
        if(what == "on")
        {
           foreach (GameObject canv in Canvaslist)
           {
                canv.GetComponent<Canvas>().enabled = true;
           }
        }
        else if(what == "off")
        {
            foreach (GameObject canv in Canvaslist)
            {
                canv.GetComponent<Canvas>().enabled = false;
            }
        }
    }
}

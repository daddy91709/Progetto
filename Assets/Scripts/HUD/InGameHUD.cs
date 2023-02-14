using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameHUD: MonoBehaviour
{

    public static bool is_paused= false;
    public GameObject menuPausa, controlli, finePartita;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //quando viene premuto esc (o tasto indietro su mobile)
        {
            if(is_paused) resume(); //se si è già in pausa, riprendi
            else pause(); //altrimenti vai in pausa
        }
    }

    public void resume()
    {
        menuPausa.SetActive(false); //rendi invisibile il menu
        controlli.SetActive(true);
        Time.timeScale= 1f; //riprendi il movimento
        is_paused=false;
    }

    public void pause()
    {
        menuPausa.SetActive(true); //rendi visibile il menu
        controlli.SetActive(false);
        Time.timeScale= 0f; //stoppa il movimento
        is_paused=true;
    }

    public void FinePartita()
    {
        //decommentare per utilizzare la schermata di fine partita senza statistiche
        
        /*
        finePartita.SetActive(true); //rendi visibile il menu
        controlli.SetActive(false);
        Time.timeScale= 0f; //stoppa il movimento
        */

        SceneManager.LoadScene("FinePartita");
    }

    public void Menu()
    {
        Time.timeScale=1f; //il gioco era in pausa prima di tornare al menu, riprende il movimento
        SceneManager.LoadScene("Menu Iniziale"); //carica la scena del menu
    }

    public void Quit()
    {
        Application.Quit(); //chiudi l'applicazione
    }

    public void NewGame()
    {
        Time.timeScale=1f; //il gioco era in pausa prima di tornare al menu, riprende il movimento
        SceneManager.LoadScene("Gioco");
    }
}
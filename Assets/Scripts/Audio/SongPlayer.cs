using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class SongPlayer : MonoBehaviour
{
    private string[] scenesToPlayIn= {"Menu Iniziale", "Player Selection", "FinePartita", "Login-Register"};

    void Start()
    {
        // Check if there is an existing instance of the SongPlayer game object
        if (FindObjectsOfType(typeof(SongPlayer)).Length > 1)
        {
            // If there is, destroy this instance
            Destroy(gameObject);
        }
        else if (scenesToPlayIn.Contains(SceneManager.GetActiveScene().name))
        {
            // If there isn't, and this is a scene that needs the song, start playing the song
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (!scenesToPlayIn.Contains(SceneManager.GetActiveScene().name))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanzaBoss : Stanza
{
    private GameObject pulsante_stairs;
    public GameObject stairs;
    private AudioSource audioSource;
    private bool sound_started = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        stairs.SetActive(false);
        pulsante_stairs = GameObject.Find("StairsBtn");
        pulsante_stairs.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public override void LateUpdate()
    {
        riferimento = GameObject.FindGameObjectWithTag("Player").transform;

        if (GetInside())
        {
            if (is_cleared())
            {
                if (first_time)
                {
                    //aggiorna il contatore per le statistiche
                    int c = PlayerPrefs.GetInt("clearedRooms");
                    PlayerPrefs.SetInt("clearedRooms", c + 1);

                    first_time = false;

                    GameObject.Find("MainSound").GetComponent<AudioSource>().mute = false;
                    audioSource.Stop();
                }
                apriPorte();
                stairs.SetActive(true);
            }
            else
            {
                chiudiPorte();

                if (!sound_started)
                {
                    sound_started = true;

                    GameObject.Find("MainSound").GetComponent<AudioSource>().mute = true;

                    audioSource.volume= PlayerPrefs.GetFloat("MusicVolume");
                    audioSource.Play();
                }
            }
        }
    }
}

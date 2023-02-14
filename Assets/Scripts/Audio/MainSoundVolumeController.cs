using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundVolumeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume= PlayerPrefs.GetFloat("MusicVolume");
    }
}

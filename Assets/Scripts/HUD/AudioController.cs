using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] Slider effectSlider, musicSlider;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("EffectsVolume"))
        {
            PlayerPrefs.SetFloat("EffectsVolume", 0.5f);
        }
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.5f);
        }

        Load();
    }

    private void Load()
    {
        effectSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("EffectsVolume", effectSlider.value);
        PlayerPrefs.GetFloat("MusicVolume", musicSlider.value);
    }

    public void SaveEffectsValue()
    {
        PlayerPrefs.SetFloat("EffectsVolume", effectSlider.value);
    }

    public void SaveMusicValue()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        audioSource.volume= musicSlider.value;
    }
}

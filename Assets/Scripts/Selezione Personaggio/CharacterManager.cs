using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CharacterManager : MonoBehaviour
{
    public SpriteRenderer selected_character;
    public TextMeshProUGUI hp,atk,spd;
    public DbPersonaggi db_personaggi;
    private int selezione=0;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selezione personaggio")) selezione=0;
        else Load();
        
        UpdateCharacter(selezione);
    }

    public void Next()
    {
        selezione++;
        if(selezione> db_personaggi.CharacterCount-1) selezione=0;

        UpdateCharacter(selezione);
        Save();
    }

    public void Prev()
    {
        selezione--;
        if(selezione< 0) selezione= db_personaggi.CharacterCount-1;

        UpdateCharacter(selezione);
        Save();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gioco");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu Iniziale");
    }
    private void UpdateCharacter(int selezione)
    {
        SpritePersonaggi selezionato= db_personaggi.GetCharacter(selezione);
        selected_character.sprite= selezionato.sprite;
        hp.text= selezionato.hp.ToString();
        atk.text= selezionato.atk.ToString();
        spd.text= selezionato.spd.ToString();
    }

    private void Load()
    {
        selezione= PlayerPrefs.GetInt("selezione personaggio");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selezione personaggio",selezione);
    }
}

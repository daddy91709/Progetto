using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{

    public Controlli controlli;
    private int coins = 0;
    private TextMeshProUGUI coin_text;
    // Start is called before the first frame update
    void Start()
    {
        coin_text = Canvas.FindObjectOfType<TextMeshProUGUI>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Coin")
        {
            PlaySound(other.gameObject);
            coins++;
            UpdateCoins();

            Destroy(other.gameObject, 1);
        }
        if (other.transform.tag == "Potion")
        {
            PlaySound(other.gameObject);
            controlli.puntiFerita += 2;
            if (controlli.puntiFerita > controlli.puntiFeritaMassimi) controlli.puntiFerita = controlli.puntiFeritaMassimi;

            Destroy(other.gameObject, 1);
        }
        if (other.transform.tag == "BigPotion")
        {
            PlaySound(other.gameObject);
            controlli.puntiFerita += 5;
            if (controlli.puntiFerita > controlli.puntiFeritaMassimi) controlli.puntiFerita = controlli.puntiFeritaMassimi;

            Destroy(other.gameObject, 1);
        }
    }

    private void PlaySound(GameObject obj)
    {
        AudioSource audio = obj.GetComponent<AudioSource>();
        audio.enabled = true;
        audio.volume= PlayerPrefs.GetFloat("EffectsVolume");
        audio.Play();
        obj.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void setCoinText(TextMeshProUGUI coin_text)
    {
        this.coin_text = coin_text;
    }

    public void UpdateCoins()
    {
        PlayerPrefs.SetInt("coins", coins); //aggiorna il contatore nelle statistiche
        coin_text.text = coins.ToString();
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SetCoins(int amount)
    {
        coins = amount;
    }

    public void DecreaseCoins(int amount)
    {
        coins -= amount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercante : MonoBehaviour
{
    public DbMercante dbMercante;
    public ItemMercanteObj[] items;
    private GameObject pulsante_shop, personaggio, item;
    private Pickup pickup;
    private int index;
    private TextMesh testo;
    private GameObject textBaloon;
    private string nome;
    private int prezzo;
    void Awake()
    {
        pulsante_shop = GameObject.Find("ShopBtn");

        items = dbMercante.items;
        index = Random.Range(0, 2);

        nome = items[index].nome;
        prezzo = items[index].prezzo;
        item = items[index].item;
    }

    void Start()
    {
        Invoke("GetPlayerReference",1);

        pulsante_shop.SetActive(false);
        
        testo = GetComponentInChildren<TextMesh>();
        textBaloon = transform.GetChild(1).gameObject;

        testo.text = "Hey, i think you might need a " + nome + ",\nhow about " + prezzo + " coins?";

        textBaloon.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pulsante_shop.SetActive(true);

            textBaloon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pulsante_shop.SetActive(false);

            testo.text = "Hey, i think you might need a " + nome + ",\nhow about " + prezzo + " coins?";
            textBaloon.SetActive(false);
        }
    }

    public void ShopItem()
    {
        if (prezzo <= pickup.GetCoins())
        {
            //Spawna l'oggetto acquistato    
            Instantiate(item, transform.position, Quaternion.identity, null);

            //scala le monete relative al prezzo dell'oggetto e mostra il nuovo totale
            pickup.DecreaseCoins(prezzo);
            pickup.UpdateCoins();

            //il mercante se ne va
            Destroy(gameObject);
        }
        else
        {
            testo.text = "You better make some coins and come back later";
        }
    }

    public void GetPlayerReference()
    {
        pickup = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
    }
}

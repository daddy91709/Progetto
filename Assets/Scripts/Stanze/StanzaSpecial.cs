using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StanzaSpecial : MonoBehaviour
{
    private GameObject pulsante_take, pulsante_atk;
    //private Transform riferimento;
    Vector3 posizione_stanza; //centro della stanza
    // Start is called before the first frame update
    void Start()
    {
        posizione_stanza= GetComponent<Transform>().position;
        pulsante_atk= GameObject.Find("AttackBtn");
        pulsante_take= GameObject.Find("TakeBtn");
        pulsante_take.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the trigger range, enable the enableButton and disable the disableButton.
        if (other.gameObject.tag == "Player")
        {
            pulsante_atk.SetActive(false);
            pulsante_take.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If the player exits the trigger range, disable the enableButton and enable the disableButton.
        if (other.gameObject.tag == "Player")
        {
            pulsante_atk.SetActive(true);
            pulsante_take.SetActive(false);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private GameObject pulsante_end;
    // Start is called before the first frame update
    void Awake()
    {
        pulsante_end = GameObject.Find("EndBtn");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pulsante_end.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pulsante_end.SetActive(false);
        }
    }

    public void FinePartita()
    {
        Debug.Log("Fine Partita");
        SceneManager.LoadScene("FinePartita");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public int prossimoLivello = 2;
    private GameObject pulsante_stairs;
    // Start is called before the first frame update
    void Awake()
    {
        pulsante_stairs = GameObject.Find("StairsBtn");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pulsante_stairs.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pulsante_stairs.SetActive(false);
        }
    }

    public void ProssimoLivello()
    {
        GameObject player = GameObject.Find("PG").transform.GetChild(0).gameObject;
        player.transform.SetParent(null);
        DontDestroyOnLoad(player);

        string scena = "Gioco" + prossimoLivello;
        
        Scene previous= SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(scena);
        SceneManager.UnloadSceneAsync(previous);
    }
}

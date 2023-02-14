using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stanza : MonoBehaviour
{
    public GameObject nemici, porte_aperte, porte_chiuse;
    protected Transform riferimento;
    Vector3 posizione_stanza; //centro della stanza
    //float x_distance= 3.68f/2; //distanza tra il centro della stanza e il muro sull'asse x
    //float y_distance= 2.08f/2; //distanza tra il centro della stanza e il muro sull'asse y
    protected bool is_inside, minion_inside, first_time = true;

    // Start is called before the first frame update
    public virtual void Start()
    {
        porte_chiuse.SetActive(false);
        posizione_stanza = GetComponent<Transform>().position;
    }

    public virtual void LateUpdate()
    {
        riferimento = GameObject.FindGameObjectWithTag("Player").transform;

        if (GetInside())
        {
            //Debug.Log("stanza: "+ posizione_stanza.x+"; "+posizione_stanza.y+"  x: "+riferimento.position.x+"y: "+riferimento.position.y+"\n cleared: "+is_cleared()+"  inside: "+player_is_inside());
            if (is_cleared())
            {
                if (first_time)
                {
                    //aggiorna il contatore per le statistiche
                    int c = PlayerPrefs.GetInt("clearedRooms");
                    PlayerPrefs.SetInt("clearedRooms", c + 1);

                    first_time = false;
                }
                apriPorte();
            }
            else chiudiPorte();
        }
    }

    public static bool object_is_inside(Vector3 posizione, Vector3 reference, float xd, float yd)
    {
        return
            (reference.x <= (posizione.x + xd - 0.35f) && reference.x >= (posizione.x - xd + 0.35f))
            &&
            (reference.y <= (posizione.y + yd - 0.35f) && reference.y >= (posizione.y - yd + 0.35f));
    }

    protected bool is_cleared()
    {
        return !(nemici.transform.childCount > 0);
    }

    protected void chiudiPorte()
    {
        porte_aperte.SetActive(false);
        porte_chiuse.SetActive(true);
    }

    protected void apriPorte()
    {
        porte_aperte.SetActive(true);
        porte_chiuse.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            is_inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            is_inside = false;
        }
    }

    public bool GetInside()
    {
        return is_inside;
    }
}

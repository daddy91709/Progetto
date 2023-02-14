using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrendiArma : MonoBehaviour
{
    private GameObject playerSword,altarSword;
    private Transform spada1,spada2;
    public GameObject textPrefab;
    private GameObject testo;

    // Start is called before the first frame update
    /*void Start()
    {
        // Use the Invoke method to call the GetGameObjectReferences method after a specific amount of time has passed.
        Invoke("PrendiRiferimenti", 1.0f);
    }
    void PrendiRiferimenti()
    {
        playerSword= GameObject.FindWithTag("PlayerSword");
        altarSword= GameObject.FindWithTag("AltarSword");
        
        spada1= playerSword.transform.GetChild(0);
        spada2= altarSword.transform.GetChild(0);
    }*/
    public void ScambiaArma()
    {
        playerSword= GameObject.FindWithTag("PlayerSword");
        altarSword= GameObject.FindWithTag("AltarSword");
        
        spada1= playerSword.transform.GetChild(0);
        spada2= altarSword.transform.GetChild(0);

        Vector3 temp_posizione= spada1.position;
        Quaternion temp_rotation = spada1.rotation;

        Debug.Log("rotazione1 "+ temp_rotation);

        //posa la spada1 sull'altare
        spada1.position= altarSword.transform.position;
        spada1.rotation= Quaternion.identity;//new Quaternion(0,0,0,1);
        spada1.localScale= new Vector3(2.2f,2.2f,0f);
        spada1.GetComponent<Animator>().enabled= false;

        //raccogli la spada2 dall'altare
        spada2.position= temp_posizione;
        spada2.rotation= temp_rotation;
        spada2.localScale= new Vector3(1.8f,1.8f,0f);
        spada2.GetComponent<Animator>().enabled= true;

        spada1.transform.SetParent(altarSword.transform);
        spada2.transform.SetParent(playerSword.transform);

        testo= Instantiate<GameObject>(textPrefab, altarSword.transform.position, Quaternion.identity);
        testo.transform.SetParent(altarSword.transform);
        testo.GetComponent<TextMesh>().text= spada2.name;
    }
}
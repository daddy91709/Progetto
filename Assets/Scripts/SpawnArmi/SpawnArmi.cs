using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArmi : MonoBehaviour
{
    private int rand;
    public DbArmi armi_db;
    private ArmiObj[] arrayArmi;
    private Transform position;
    private GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        position= GetComponent<Transform>();
        arrayArmi= armi_db.armi;

        rand= Random.Range(1,100);//numero random da 1 a 100
        
        generaArma();
    }
    private void Shuffle()
    {
         for (int i = 0; i < arrayArmi.Length; i++) {
             int rnd = Random.Range(0, arrayArmi.Length);
             ArmiObj temp = arrayArmi[rnd];
             arrayArmi[rnd] = arrayArmi[i];
             arrayArmi[i] = temp;
         }
    }
    private void generaArma()
    {
        Shuffle();
        for(int i=0; i<armi_db.Count; i++)
        {
            if(rand>= arrayArmi[i].rarity)
            {
                sword= Instantiate<GameObject>(arrayArmi[i].sword,position);
                sword.transform.localScale= new Vector3(2.2f,2.2f,0f);
                sword.GetComponent<Animator>().enabled= false;
                sword.name= arrayArmi[i].sword.name;
                return;
            }
        }
        Shuffle();
        sword= Instantiate<GameObject>(arrayArmi[0].sword,position);
        sword.transform.localScale= new Vector3(2.2f,2.2f,0f);
        sword.GetComponent<Animator>().enabled= false;
        sword.name= arrayArmi[0].sword.name;
    }
}

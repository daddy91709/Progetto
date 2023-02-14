using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanzaFinale : Stanza
{
    private GameObject pulsante_end;
    public GameObject king;
    private Collider2D kingCollider;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        pulsante_end= GameObject.Find("EndBtn");
        pulsante_end.SetActive(false);

        kingCollider= king.GetComponent<Collider2D>();
        kingCollider.enabled= false;
    }

     public override void LateUpdate()
    {
        riferimento =  GameObject.FindGameObjectWithTag("Player").transform;

        if (GetInside())
        {
            if (is_cleared())
            {
                apriPorte();
                kingCollider.enabled= true;
            } 
            else chiudiPorte();
        }
    }
}

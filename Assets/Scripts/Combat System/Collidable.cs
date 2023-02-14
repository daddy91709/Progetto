using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
   public ContactFilter2D filter;
   private Collider2D boxCollider;
   private Collider2D[] hits = new Collider2D[10];

   protected virtual void Start()
   {
    boxCollider = GetComponent<Collider2D>();
   }

   protected virtual void Update()
   {
    boxCollider.OverlapCollider(filter, hits);
    for(int i=0; i<hits.Length; i++)
    {
        //Funzionamento collisioni
        if(hits[i]==null)
        continue;

        OnCollide(hits[i]);

        //Libero l'array
        hits[i]=null;
    }
   }

   protected virtual void OnCollide(Collider2D coll)
   {
    Debug.Log("OnCollide non è stato implementato su "+this.name);
   }
}

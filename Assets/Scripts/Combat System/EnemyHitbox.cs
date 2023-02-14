using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public float danno=1;
    public float pushForce=3;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag=="Player") //&& coll.name=="Giocatore") //prima della modifica il coll.tag era "Eroe"
        {
            Danno dmg = new Danno
            {
                DannoFatto=danno,
                origin=transform.position,
                pushForce=pushForce
            };

            coll.SendMessage("DannoRicevuto",dmg);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Personaggi
{
    //protected BoxCollider2D boxCollider;
    //protected RaycastHit2D hit;
    protected Vector3 movimento;

    //riceve l'input della direzione in cui muoversi, la velocità con cui muoversi, il suo corpo rigido da muovere, lo sprite associato all'animazione che si vuole far partire
    protected virtual void UpdateMotor(Vector3 input, float velocita, Rigidbody2D rigidbody, Animazione anim)
    {
        //calcolo del vettore della direzione
        movimento = new Vector3(input.x*velocita, input.y*velocita, 0);
        movimento += pushDirection;

        //calcolo della prossima push direction (?)
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //viene applicata la velocità all'oggetto
        rigidbody.velocity = movimento;

        //Animazione
        Vector2 mov= new Vector2(movimento.x, movimento.y); //salva il vettore del movimento
        anim.set_direzioni(mov); //invoca il metodo per far partire l'animazione giusta
    }
}
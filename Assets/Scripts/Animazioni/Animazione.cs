using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animazione : MonoBehaviour
{

    private Animator animator;
    public string[] idleDir = { "idle UP", "idle UPSX", "idle SX", "idle DOWNSX", "idle DOWN", "idle DOWNDX", "idle DX", "idle UPDX" }; //nomi animazioni idle
    public string[] walkDir = { "walk UP", "walk UPSX", "walk SX", "walk DOWNSX", "walk DOWN", "walk DOWNDX", "walk DX", "walk UPDX" }; //nomi animazioni di corsa

    int ultima_dir = 4;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private int indiceDirezione(Vector2 vector) //metodo che ritorna l'indice relativo ad una delle 8 direzioni a partire dal vettore della sua velocity
    {
        Vector2 dirBase = vector.normalized; //normalized ritorna il versore dell'angolo
        float passo = 360 / 8; //divido l'angolo giro in 8 spicchi
        float angolo = Vector2.SignedAngle(Vector2.up, dirBase); //ottengo l'angolo del vettore della direzione di dirBase calcolando l'angolo dal vettore che punta verso l'alto fino a dirBase

        float offset = passo / 2;//un offset permette di centrare l'angolo nello spicchio giusto

        angolo += offset;
        if (angolo < 0) angolo += 360; //converti un angolo negativo in positivo

        float indice = angolo / passo; //trovo in quale spicchio si trova l'angolo, questo sarà il mio indice
        return (int)indice;
    }

    public void set_direzioni(Vector2 vector)
    {
        string[] direzioni = null;

        if (vector.magnitude < 0.1) //il personaggio è fermo o quasi
        {
            direzioni = idleDir;
        }
        else
        {
            direzioni = walkDir;
            ultima_dir = indiceDirezione(vector); //salvo l'ultima direzione per mantenere il personaggio fermo nella direzione in cui stava andando
        }

        animator.Play(direzioni[ultima_dir]); //l'animator fa partire l'animazione col nome corrispondente
    }

}

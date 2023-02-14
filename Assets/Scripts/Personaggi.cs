using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaggi : MonoBehaviour
{
    public float puntiFerita = 10;
    public float puntiFeritaMassimi = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float tempoImmunita = 1.0f;
    protected float immune;
    protected Vector3 pushDirection;
    protected SpriteRenderer spriteRenderer;

    public virtual void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    protected virtual void DannoRicevuto(Danno dmg)
    {
        if (Time.time - immune > tempoImmunita)
        {
            immune = Time.time;
            puntiFerita -= dmg.DannoFatto;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            StartCoroutine(DamageColor());

            if (puntiFerita <= 0)
            {
                puntiFerita = 0;
                Morte();
            }
        }
    }

    protected virtual void Morte()
    {
        Destroy(gameObject);
    }

    public IEnumerator DamageColor()
    {
        spriteRenderer.color= Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color= Color.white;
    }
}
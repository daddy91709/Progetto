using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemico : Mover
{
    public float soundInterval = 3;
    private bool soundStarted = false;
    public Drop drop;
    public new Rigidbody2D rigidbody;
    public Animazione anim;

    private Transform playerTransform;
    private Vector3 startingPosition;

    //parametri inseguimento
    public float velocita;

    //Hitbox
    public ContactFilter2D filter;
    private Collider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    private Vector3 direction;
    private Stanza stanza;

    public override void Start()
    {
        base.Start();
        drop.Start();
        stanza = transform.GetComponentInParent<Transform>().GetComponentInParent<Stanza>();
        startingPosition = transform.position;
        hitbox = transform.GetComponent<CircleCollider2D>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        //Eroe si trova nel range?
        if (stanza.GetInside())
        {
            direction = Vector3.Slerp(rigidbody.velocity, (playerTransform.position - transform.position).normalized, velocita);
            if (!soundStarted)
            {
                soundStarted = true;
                StartCoroutine(PlaySound());
            }
        }
        else
        {
            direction = Vector3.zero;
        }

        //if(is_inside) Debug.Log("Inside");
        UpdateMotor(direction, velocita, rigidbody, anim);

        hitbox.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            //Funzionamento collisioni
            if (hits[i] == null)
                continue;
        }
    }

    protected override void DannoRicevuto(Danno dmg)
    {
        base.DannoRicevuto(dmg);

        //aggiunto l'aggiornamento del contatore per le stats
        float c = PlayerPrefs.GetFloat("damageDealt");
        PlayerPrefs.SetFloat("damageDealt", c + dmg.DannoFatto);
    }
    protected override void Morte()
    {
        //aggiorna il contatore per le statistiche
        int c = PlayerPrefs.GetInt("kills");
        PlayerPrefs.SetInt("kills", c + 1);

        drop.DropLoot();
        Destroy(gameObject);
    }

    private IEnumerator PlaySound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume= PlayerPrefs.GetFloat("EffectsVolume");
        while (true)
        {
            audio.Play();
            yield return new WaitForSeconds(soundInterval);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlli : Mover
{
public Rigidbody2D p_rb; //riferimento alla componente Rigidbody2D del player
public float velocita;
public Animazione anim;
public RotazioneVersoNemici rotazione;
private InGameHUD HUD;
private HealtBar healtBar;
private Vector2 direzione;
private Joystick joystick;

    override public void Start()
    {
        base.Start();

        //ottieni il riferimento al joystick per il movimento
        joystick= FindObjectOfType<Joystick>();

        //ottieni il iriferimento alla barra della vita
        healtBar= GameObject.Find("HealtBar").GetComponent<HealtBar>();

        //setta i valori iniziali della barra della vita
        healtBar.setMaxHealt(puntiFeritaMassimi);
        healtBar.setHealt(puntiFeritaMassimi);

        HUD= GameObject.Find("Canvas").GetComponent<InGameHUD>();
    }

    private void FixedUpdate() //calcoli fisici e istruzioni che non dipendono dal framerate
    {
        //Input
        float movX= joystick.Horizontal;
        float movY= joystick.Vertical;

        //controlli extra da tastiera
        movX += Input.GetAxisRaw("Horizontal");
        movY += Input.GetAxisRaw("Vertical");
        
        direzione= new Vector2(movX,movY).normalized;

        //Movimento
        UpdateMotor(direzione, velocita, p_rb, anim);
    }

    protected override void UpdateMotor(Vector3 input, float velocita, Rigidbody2D rigidbody, Animazione anim)
    {
        //calcolo del vettore della direzione
        movimento = new Vector3(input.x*velocita, input.y*velocita, 0);
        movimento += pushDirection;

        //calcolo della prossima push direction (?)
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //viene applicata la velocità all'oggetto
        rigidbody.velocity = movimento;

        //Animazione
        if(rotazione.GetEngaging())
        {
            anim.set_direzioni(rotazione.GetDirection());
        }
        else
        {
        Vector2 mov= new Vector2(movimento.x, movimento.y); //salva il vettore del movimento
        anim.set_direzioni(mov); //invoca il metodo per far partire l'animazione giusta
        }
    }

    private void Update()
    {
        healtBar.setHealt(puntiFerita); //il valore della barra della vita viene costantemente aggiornato 
        //(potrebbe essere ottimizzato chiamando il metodo solo quando si subisce danno con un override di DannoRicevuto in Personaggi)
    }

    protected override void Morte()
    {
      Debug.Log("Morte");
      HUD.FinePartita();
    }

    protected override void DannoRicevuto(Danno dmg)
    {
        if (Time.time - immune > tempoImmunita)
        {
            immune = Time.time;
            puntiFerita -= dmg.DannoFatto;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            StartCoroutine(base.DamageColor());

            GetComponent<AudioSource>().volume= PlayerPrefs.GetFloat("EffectsVolume");
            GetComponent<AudioSource>().Play();

            if (puntiFerita <= 0)
            {
                puntiFerita = 0;
                Morte();
            }
        }

        //aggiunto l'aggiornamento del contatore per le stats
        float c= PlayerPrefs.GetFloat("damageTaken");
        PlayerPrefs.SetFloat("damageTaken",c+dmg.DannoFatto);
    }

    public void SetHealtBar(HealtBar healtBar)
    {
        this.healtBar=healtBar;
    }
    public void SetInGameHUD(InGameHUD HUD)
    {
        this.HUD=HUD;
    }

    public void SetJoystick(Joystick joystick)
    {
        this.joystick= joystick;
    }

    public Pickup GetPickup()
    {
        return transform.GetComponent<Pickup>();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//la classe dovrebbe estendere Mover ed utilizzare il metodo UpdateMotor ma per motivi di complessità del movimento la seguente classe rimarrà cosi
public class movimento_placeholder : Personaggi
{
    public Rigidbody2D rb; //riferimento all componente Rigidbody2D del boss
    public float velocita;
    public Animazione anim;
    private GameObject player; // The player game object
    private HealtBar healtBar;
    public float circleRadius = 0.5f;
    public float circleDistance = 1.2f;
    public float chaseDistance = 3f;

    public override void Start()
    {
        base.Start();
        healtBar = GetComponentInChildren<HealtBar>();
        //setta i valori iniziali della barra della vita
        healtBar.setMaxHealt(puntiFeritaMassimi);
        healtBar.setHealt(puntiFeritaMassimi);
    }

    void FixedUpdate()
    {
        player =  GameObject.FindGameObjectWithTag("Player");

        float distance = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log("-distance: "+distance+" -pos pg: "+player.transform.position+" -pos boss: "+transform.position);

        if (distance <= circleDistance) //se sei molto vicino il boss deve ruorare intorno al giocatore
        {
            // Calculate the boss's position in the circle
            float x = player.transform.position.x + Mathf.Cos(Time.time * velocita) * circleRadius;
            float y = player.transform.position.y + Mathf.Sin(Time.time * velocita) * circleRadius;

            // Set the boss's velocity to move it in the circle
            rb.velocity = new Vector2(x, y) - rb.position;
        }
        else if (distance <= chaseDistance) //altrimenti se si trova abbastanza vicino inseguilo
        {
            Vector3 movement = (player.transform.position - transform.position).normalized;
            rb.velocity = movement * velocita;
        }
        else rb.velocity = Vector2.zero; //altrimenti non muoverti

        anim.set_direzioni(rb.velocity); //invoca il metodo per far partire l'animazione giusta
    }

    private void Update()
    {
        healtBar.setHealt(puntiFerita); //il valore della barra della vita viene costantemente aggiornato 
        //(potrebbe essere ottimizzato chiamando il metodo solo quando si subisce danno con un override di DannoRicevuto in Personaggi)
    }
    protected override void DannoRicevuto(Danno dmg)
    {
        base.DannoRicevuto(dmg);

        //aggiunto l'aggiornamento del contatore per le stats
        float c= PlayerPrefs.GetFloat("damageDealt");
        PlayerPrefs.SetFloat("damageDealt",c+dmg.DannoFatto);
    }
    override protected void Morte()
    {
        //aggiorna il contatore per le statistiche
        int c= PlayerPrefs.GetInt("kills");
        PlayerPrefs.SetInt("kills",c+1);

        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arma : Collidable
{
   //danno
   public float PuntiDanno = 1f;
   public float pushForce = 2.0f;

   //colpo
   public float cooldown = 0.5f;
   private Animator anim;

   private float UltimoColpo;
   private bool swinging= false;
   private Button btn;

   protected override void Start()
   {
    base.Start();
    anim=GetComponent<Animator>();
    btn= GameObject.Find("AttackBtn").transform.GetChild(0).GetComponent<Button>();
   }

   protected override void Update()
   {
    base.Update();

    //btn.onClick.Invoke();

    if(swinging) //da sostituire con tap del pulsante a schermo
    {
        if(Time.time - UltimoColpo > cooldown)
        {
            UltimoColpo=Time.time;
            Swing();
        }
        swinging= false;
    }
   }

   protected override void OnCollide(Collider2D coll)
   {
    if(coll.tag=="Nemici" || coll.tag=="Minion")
    {
        //Creo un oggetto danno
        Danno dmg = new Danno
        {
            DannoFatto=PuntiDanno,
            origin=transform.position,
            pushForce=pushForce
        }; 

        coll.SendMessage("DannoRicevuto",dmg);
    }
   }

   public void Swing()
   {
    swinging= true;

    GetComponent<AudioSource>().volume= PlayerPrefs.GetFloat("EffectsVolume");
    GetComponent<AudioSource>().Play();
    
    anim.SetTrigger("Swing");
   }
}

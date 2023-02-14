using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMove : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject attackPrefab; //The prefab for the attack game object
    public int rand;
    public float startingRadius = 0f; //The radius at which the attack game objects should be positioned around the boss
    public float radiusIncrement = 0.10f; //aumento del raggio tra uno spawn e l'altro all'interno di una serie
    public float cooldown = 5f; //tempo di  attesa tra una serie di attacchi e l'altra
    public float maxSpread = 2f; //massima espansione degli attacchi
    public float probAtk = 60; //probabilità di iniziare la serie di attacchi
    public int numAttacks = 8; //The number of attack game objects to instantiate
    public float interval = 0.5f; //The interval (in seconds) at which the attack game objects should be instantiated
    private Stanza stanza;
    private GameObject player;
    private bool flag;
    void Start()
    {
        flag = true;
        stanza = transform.GetComponentInParent<Transform>().GetComponentInParent<Stanza>();

        audioSource.volume= PlayerPrefs.GetFloat("EffectsVolume");
    }

    void Update()
    {
        player =  GameObject.FindGameObjectWithTag("Player");

        //Debug.Log("flag: "+flag);

        if (stanza.GetInside() && flag)
        {
            flag = false;
            StartCoroutine(SpawnAttacks());
        }
        else if (!stanza.GetInside())
        {
            StopCoroutine(SpawnAttacks());
            flag = true;
        }
    }

    IEnumerator SpawnAttacks()
    {
        while (true)
        {
            // Destroy any previously spawned attack game objects
            GameObject[] attacks = GameObject.FindGameObjectsWithTag("Attack");
            //Debug.Log("n. attacks: " + attacks.Length);
            foreach (GameObject attack in attacks)
            {
                Destroy(attack);
            }

            if (attacks.Length > 8)
            {
                yield return new WaitForSeconds(cooldown); // Wait for the specified cooldown before continuing
            }

            // se il raggio è aumentato troppo, resettalo e aspetta per iniziare una nuova serie di attacchi
            if (startingRadius > maxSpread)
            {
                startingRadius = 0.25f;
                // Wait for the specified cooldown before continuing
                yield return new WaitForSeconds(cooldown);
            }

            // Calculate the angle at which the attack game objects should be positioned around the boss
            float angle = 360.0f / numAttacks;

            // Instantiate the attack game objects at the specified radius and angle
            for (int i = 0; i < numAttacks; i++)
            {
                // Calculate the position of the attack game object
                float x = GetComponent<Transform>().position.x + (startingRadius) * Mathf.Cos(angle * i * Mathf.Deg2Rad);
                float y = GetComponent<Transform>().position.y + (startingRadius) * Mathf.Sin(angle * i * Mathf.Deg2Rad);
                Vector2 position = new Vector2(x, y);

                // Instantiate the attack game object
                GameObject attack = Instantiate(attackPrefab, position, Quaternion.identity, transform);

                audioSource.Play();
            }
            // Aumenta la distanza di spawn sell'attacco
            startingRadius += radiusIncrement;
            // Wait for the specified interval before spawning the next batch of attack game objects
            yield return new WaitForSeconds(interval);
        }
    }
}
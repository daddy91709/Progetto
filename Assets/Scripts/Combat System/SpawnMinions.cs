using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinions : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject minonPrefab; //The prefab for the minion game object
    public float radius = 0f; //The radius at which the minion game objects should be positioned around the boss
    public float cooldown = 10f; //tempo di  attesa tra una serie di spawn e l'altra
    public int numMinions = 3; //The number of minion game objects to instantiate
    public float interval = 0.5f; //The interval (in seconds) at which the minion game objects should be instantiated
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
        player = GameObject.FindGameObjectWithTag("Player"); ;
        if (stanza.GetInside() && flag)
        {
            flag = false;
            StartCoroutine(Spawnminions());
        }
        else if (!stanza.GetInside())
        {
            StopCoroutine(Spawnminions());
            flag = true;
        }
    }

    IEnumerator Spawnminions()
    {
        while (true)
        {
            GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
            //Debug.Log("n. minions: "+minions.Length);

            if (minions.Length > 2)
            {
                yield return new WaitForSeconds(cooldown); // Wait for the specified cooldown before continuing
            }

            // Calculate the angle at which the minion game objects should be positioned around the boss
            float angle = 360.0f / numMinions;

            // Instantiate the minion game objects at the specified radius and angle
            for (int i = 0; i < numMinions; i++)
            {
                // Calculate the position of the minion game object
                float x = GetComponent<Transform>().position.x + (radius) * Mathf.Cos(angle * i * Mathf.Deg2Rad);
                float y = GetComponent<Transform>().position.y + (radius) * Mathf.Sin(angle * i * Mathf.Deg2Rad);
                Vector2 position = new Vector2(x, y);

                // Instantiate the minion game object if it is inside the room
                if (Stanza.object_is_inside(stanza.transform.position, position, 3.68f / 2, 1.08f / 2))
                {
                    GameObject minion = Instantiate(minonPrefab, position, Quaternion.identity, transform);
                    minion.transform.localScale /= 0.24f;

                    audioSource.Play();
                }
            }
            // Wait for the specified interval before spawning the next batch of minion game objects
            yield return new WaitForSeconds(interval);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotazioneVersoNemici : MonoBehaviour
{
    public float rotationSpeed = 180f;// The speed at which the sword will rotate, in degrees per second.
    public Transform player; // The player character that the sword is attached to.
    public float engageDistance = 2f;
    private bool engaging;
    private SpriteRenderer sprite;
    private GameObject nemico;
    private GameObject[] enemies, minions; // array of enemies
    private Vector2 direction;

    void Update()
    {
        Vector2 playerDirection = player.GetComponent<Rigidbody2D>().velocity;

        enemies = GameObject.FindGameObjectsWithTag("Nemici");//ottieni il riferimento all'array di nemici aggiornato
        minions = GameObject.FindGameObjectsWithTag("Minion");//ottieni ilo rifermento all'array di minions

        //crea una lista con gli elementi del primo array, poi aggiungi quelli del secondo array; quindi trasforma il primo array nella lista concatenata
        List<GameObject> concatenatedList = new List<GameObject>(enemies);
        foreach (GameObject obj in minions)
        {
            concatenatedList.Add(obj);
        }
        enemies = concatenatedList.ToArray();

        nemico = NearestEnemy();

        //se è abbastanza vicino per ingaggiare il nemico punta la spada verso di lui
        if (nemico != null && Vector2.Distance(nemico.transform.position, player.position) < engageDistance)
        {
            // Rotate the sword towards the nearest enemy
            engaging = true;
            direction = nemico.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle - 90f), rotationSpeed * Time.deltaTime);
        }
        else //altrimenti se sei troppo lontano punta la spada nella direzione in cui ti muovi
        {
            engaging = false;
            if (playerDirection == Vector2.zero)// If the player is not moving, don't rotate the sword.
            {
                return;
            }
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;// Calculate the angle of the player's movement, in degrees.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle - 90f), rotationSpeed * Time.deltaTime);// Rotate the sword towards the player's movement direction.
        }

        NascondiSpada();
    }

    private GameObject NearestEnemy()
    {
        // Find the nearest enemy
        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector2.Distance(enemies[i].transform.position, player.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemies[i];
            }
        }
        return nearestEnemy;
    }

    private void NascondiSpada()
    {
        //nascondi la spada dietro il personaggio quando questo è di schiena
        sprite = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        if (transform.eulerAngles.z <= 135 && transform.eulerAngles.z >= 0)
        {
            sprite.sortingOrder = -1;
        }
        else
        {
            sprite.sortingOrder = 0;
        }
    }

    public bool GetEngaging()
    {
        return engaging;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}

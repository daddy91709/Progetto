using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPersonaggio : MonoBehaviour
{
    public DbPersonaggi db_personaggi;
    public GameObject player;
    Transform position;
    // Start is called before the first frame update
    void Start()
    {
        position= GetComponent<Transform>();
        player= Instantiate<GameObject>(db_personaggi.GetCharacter(PlayerPrefs.GetInt("selezione personaggio")).prefab, position);
        resetStats();
    }

    private void resetStats()
    {
        PlayerPrefs.SetFloat("damageDealt",0);
        PlayerPrefs.SetFloat("damageTaken",0);
        PlayerPrefs.SetInt("coins",0);
        PlayerPrefs.SetInt("clearedRooms",0);
        PlayerPrefs.SetInt("kills",0);
    }
}
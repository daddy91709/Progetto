using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatsManager : MonoBehaviour
{
    public TextMeshProUGUI damageDealt, damageTaken, coins, clearedRooms, killedEnemies;
    // Start is called before the first frame update
    void Start()
    {
        damageDealt.text= "Damage Dealt: " + ((int)(PlayerPrefs.GetFloat("damageDealt")/10)).ToString();//
        damageTaken.text= "Damage Taken: " + ((int)(PlayerPrefs.GetFloat("damageTaken")/100)).ToString();//
        coins.text= "Coins: " + PlayerPrefs.GetInt("coins").ToString();//
        clearedRooms.text= "Cleared Rooms: " + PlayerPrefs.GetInt("clearedRooms").ToString();//
        killedEnemies.text= "Killed Enemies: " + PlayerPrefs.GetInt("kills").ToString();//
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public DbDrop dropsDb;
    private DropObj[] drops;
    //private Transform posizione;
    int rand;
    // Start is called before the first frame update
    public void Start()
    {
        drops= dropsDb.drops;
    }
    public void DropLoot()
    {
        rand= Random.Range(1,100);
        Shuffle();

        for(int i=0; i<drops.Length; i++)
        {
            if(rand>= drops[i].rarity)
            {
                if(drops[i].rarity<=60) //se la sua rarità è minore di 60 è sicuramente una moneta, vedo se deve spawnare in quantità maggiore
                {
                    int count= Random.Range(1,4);
                    float angle = 360.0f / count;
                    for (int j=0;j<count;j++)
                    {
                        // Calculate the position of the coin game object
                        float x = transform.position.x + 0.05f * Mathf.Cos(angle * j * Mathf.Deg2Rad);
                        float y = transform.position.y + 0.05f * Mathf.Sin(angle * j * Mathf.Deg2Rad);
                        Vector2 position = new Vector2(x, y);
                        // Instantiate the coin game object
                        Instantiate(drops[i].drop, position, Quaternion.identity);
                    }
                }
                else                    //altrimenti è un oggetto normale, lo spawno singolarmente
                {
                    Instantiate(drops[i].drop,transform.position,Quaternion.identity); 
                }
                return; 
            }
        }
    }
    private void Shuffle()
    {
         for (int i = 0; i < drops.Length; i++) {
             int rnd = Random.Range(0, drops.Length);
             DropObj temp = drops[rnd];
             drops[rnd] = drops[i];
             drops[i] = temp;
         }
    }
}

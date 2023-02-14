using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DbMercante : ScriptableObject
{
    public ItemMercanteObj[] items;

    public int Count
    {
        get
        {
            return items.Length;
        }
    }

    public ItemMercanteObj GetItem(int indice)
    {
      return items[indice];
    }
}

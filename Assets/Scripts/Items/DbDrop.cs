using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DbDrop : ScriptableObject
{
    public DropObj[] drops;

    public int Count
    {
        get
        {
            return drops.Length;
        }
    }

    public DropObj GetDrop(int indice)
    {
      return drops[indice];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DbArmi : ScriptableObject
{
    public ArmiObj[] armi;

    public int Count
    {
        get
        {
            return armi.Length;
        }
    }

    public ArmiObj GetWeapon(int indice)
    {
      return armi[indice];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DbPersonaggi : ScriptableObject
{
    public SpritePersonaggi[] characters;

    public int CharacterCount
    {
        get
        {
            return characters.Length;
        }
    }

    public SpritePersonaggi GetCharacter(int indice)
    {
      return characters[indice];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacco : MonoBehaviour
{
    arma arma;
    public void InvocaAttacco()
    {
        arma= GameObject.Find("PlayerSword").transform.GetChild(0).GetComponent<arma>();
        arma.Swing();
    }
}

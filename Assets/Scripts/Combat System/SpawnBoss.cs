using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    private Transform position;
    private int rand;
    public GameObject boss1,boss2;
    // Start is called before the first frame update
        void Start()
    {
        position= GetComponent<Transform>();
        rand= Random.Range(0,100);//numero random da 0 a 1
        generaBoss();
    }
    private void generaBoss()
    {
        if (rand>50) Instantiate<GameObject>(boss1,position);
        else Instantiate<GameObject>(boss2,position);
    }
}
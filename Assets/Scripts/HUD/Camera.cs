using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject personaggio;
    private Transform riferimento;
    private void Start()
    {
        personaggio= GameObject.FindGameObjectWithTag("Player");
        riferimento= personaggio.GetComponent<Transform>();
    }

    private void LateUpdate() //late update viene eseguito dopo update
    {
        float delta_x=0;
        float delta_y=0;

        //Debug.Log(riferimento.position.x+" "+riferimento.position.y);

        //controllo x
        if(riferimento.position.x > transform.position.x+(3.68/2))  delta_x= 3.68f;
        if(riferimento.position.x < transform.position.x-(3.68/2))  delta_x= -3.68f;

        //controllo y
        if(riferimento.position.y > transform.position.y+(2.08/2))  delta_y= 2.08f;
        if(riferimento.position.y < transform.position.y-(2.08/2))  delta_y= -2.08f;

        transform.position=new Vector3(transform.position.x+delta_x, transform.position.y+delta_y,transform.position.z);
    }
}
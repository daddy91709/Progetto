using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    // Start is called before the first frame update
     EndGame end;
    public void callFinePartita()
    {
        end= GameObject.Find("King").GetComponent<EndGame>();
        end.FinePartita();
    }
}

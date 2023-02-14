using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageButton : MonoBehaviour
{
    NextStage stairs;
    public void callProssimoLivello()
    {
        stairs= GameObject.Find("NewLevelDoors").transform.GetChild(0).GetComponent<NextStage>();
        stairs.ProssimoLivello();
    }
}

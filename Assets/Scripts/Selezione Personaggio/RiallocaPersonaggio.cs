using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RiallocaPersonaggio : MonoBehaviour
{
    GameObject personaggio;
    // Start is called before the first frame update
    void Awake()
    {
        //metti il personaggio nella stanza iniziale del nuovo livello e aggiungilo come tuo child
        personaggio= GameObject.FindGameObjectWithTag("Player");
        personaggio.transform.SetParent(transform);
        personaggio.transform.position= transform.position;

        //aggiorna gli elementi della HUD con quelli del nuovo livello
        Controlli controlli= personaggio.GetComponent<Controlli>();
        controlli.SetHealtBar(GameObject.Find("HealtBar").GetComponent<HealtBar>());
        controlli.SetInGameHUD(GameObject.Find("Canvas").GetComponent<InGameHUD>());
        controlli.SetJoystick(FindObjectOfType<Joystick>());

        //aggiorna anche l'elemento HUD delle monete e setta il quantitativo di monete del piano precedente
        controlli.GetPickup().setCoinText(Canvas.FindObjectOfType<TextMeshProUGUI>());
        controlli.GetPickup().UpdateCoins();
    }
}

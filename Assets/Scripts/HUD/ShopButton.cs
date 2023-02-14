using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    Mercante mercante;
    public void callShopItem()
    {
        mercante= GameObject.Find("Merchant").GetComponent<Mercante>();
        mercante.ShopItem();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Coin : MonoBehaviour , ICollect
{
    [SerializeField] private int _coin = 1;
    public void Collect()
    {
        FindObjectOfType<UI_CoinManager>().CollectCoin(_coin);
        Destroy(gameObject);
    }
}

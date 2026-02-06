using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Coin : MonoBehaviour , ICollect
{
    //STATS
    [SerializeField] private int _coin = 1;
    public void Collect()
    {
        UI_CoinManager coinManager = FindAnyObjectByType<UI_CoinManager>();
        if (coinManager != null )
        {
            coinManager.CollectCoin(_coin);
            Debug.Log($"Hai guadagnato {_coin} moneta!");
            Destroy(gameObject);
        }
    }
}

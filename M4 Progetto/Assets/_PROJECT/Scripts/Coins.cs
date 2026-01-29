using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private int _coins = 1;
    [SerializeField] private CoinsManager _coinsManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_coinsManager != null)
            {
                _coinsManager.CollectCoin(_coins);
            }

            Destroy(gameObject);
        }
    }
}

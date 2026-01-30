using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CoinManager : MonoBehaviour
{
    [SerializeField] private int _totalCoins = 5;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private GameObject _doorPrefab;

    private int _currentCoins = 0;
    void Start()
    {
        UpdateCoinsUI();
    }

    public void CollectCoin(int amount)
    {
        _currentCoins += amount;
        UpdateCoinsUI();

        if (_currentCoins >= _totalCoins)
        {
            OpenTheDoor();
        }
    }

    public void UpdateCoinsUI()
    {
        if (_coinText != null)
        {
            _coinText.text = $"{_currentCoins} / {_totalCoins}";
        }
    }

    private void OpenTheDoor()
    {
        _doorPrefab.SetActive(false);
        Debug.Log("Portone Aperto");
    }
}

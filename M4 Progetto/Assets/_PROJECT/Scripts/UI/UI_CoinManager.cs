using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CoinManager : MonoBehaviour
{
    //SETT
    [SerializeField] private int _totalCoins = 5;
    [SerializeField] private TMP_Text _coinText;
    //DOOR
    [SerializeField] private GameObject _door;
    //PRIVATE
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
        _door.SetActive(false);
        Debug.Log("Portone Aperto");
    }
}

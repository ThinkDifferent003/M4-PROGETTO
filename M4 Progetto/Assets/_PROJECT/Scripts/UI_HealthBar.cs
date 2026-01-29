using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    [SerializeField] private Image[] _healthPoint;

    public void UpdateUI(int currentHealth)
    {
        for (int i = 0; i < _healthPoint.Length;  i++)
        {
            if (i < currentHealth)
            {
                _healthPoint[i].enabled = true;
            }
            else
            {
                _healthPoint[i].enabled = false;
            }
        }
    }
}

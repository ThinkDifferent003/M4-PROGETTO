using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    //IMAGE
    [SerializeField] private Image[] _healthPoint;

    public void UpdateUI(int currentHealth)
    {
        for (int i = 0; i < _healthPoint.Length;  i++)
        {
            if (i < currentHealth)
            {
                _healthPoint[i].gameObject.SetActive(true);
            }
            else
            {
                _healthPoint[i].gameObject.SetActive(false);
            }
        }
    }
}

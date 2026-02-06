using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private UI_Timer _uiTimer;
    private UI_Victory _uiVictory;

    private void Start()
    {
        _uiTimer = FindAnyObjectByType<UI_Timer>();
        _uiVictory = FindAnyObjectByType<UI_Victory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiTimer.BlockTimer();
            Debug.Log("Livello Completato");

            _uiVictory.Victory();
        }
    }
}

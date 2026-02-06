using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{
    //SETT
    [SerializeField] private float _timeRemain = 120f;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private UI_GameOver _gameOverScript;
    //PRIVATE
    private bool _isTimerActive = true;

    private void Start()
    {
        DisplayText(_timeRemain);
    }
    
    void Update()
    {
        if (_isTimerActive)
        {
            if (_timeRemain > 0)
            {
                _timeRemain -= Time.deltaTime;
                DisplayText(_timeRemain);
            }
            else
            {
                Debug.Log("Tempo Scaduto");
                _timeRemain = 0;
                DisplayText(0);
                _isTimerActive = false;
                GameOver();
            }
        }
    }
    
    private void DisplayText(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (time <= 10f)
        {
            _timerText.color = Color.red;
        }
    }
    
    public void AddTime(float time)
    {
        _timeRemain += time;

        DisplayText(_timeRemain);
    }    

    private void GameOver()
    {
        if (_gameOverScript  != null)
        {
            _gameOverScript.GameOver();
        }
    }
    
    public void BlockTimer()
    {
        _isTimerActive = false;
    }
}    
    
    
    
    
    
    
    
    
    

    

    
    



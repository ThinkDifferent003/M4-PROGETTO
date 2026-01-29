using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float _timeRemain = 120f;
    [SerializeField] private TMP_Text _timerText;

    private bool _isTimerActive = true;

    private void DisplayText(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        _timerText.text = string.Format("{0:00}:{1:00}" , minutes , seconds);

        if (time <= 10f)
        {
            _timerText.color = Color.red;
        }
    }

    private void GameOver()
    {

    }

    public void BlockTimer()
    {
        _isTimerActive = false;
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
                _isTimerActive = false;
                GameOver();
            }
        }
    }
}

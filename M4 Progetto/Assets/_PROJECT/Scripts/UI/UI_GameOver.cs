using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameOver : MonoBehaviour
{
    //SETT
    [SerializeField] private GameObject _gameOver;

    private void Start()
    {
        if (_gameOver != null)
        {
            _gameOver.SetActive(false);
        }
    }

    public void GameOver()
    {
        if ( _gameOver != null)
        {
            _gameOver.SetActive(true);
        }
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Retry()
    {
        ResetGameTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        ResetGameTime();
        SceneManager.LoadScene(0);
    }

    private void ResetGameTime()
    {
        Time.timeScale = 1f;
    }

    
}

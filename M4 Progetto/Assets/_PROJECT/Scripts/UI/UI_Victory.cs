using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Victory : MonoBehaviour
{
    //SETT
    [SerializeField] private GameObject _victoryPanel;

    void Start()
    {
        if ( _victoryPanel != null )
        {
            _victoryPanel.SetActive( false );
        }
    }

    public void Victory()
    {
        if ( _victoryPanel != null )
        {
            _victoryPanel.SetActive( true );
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

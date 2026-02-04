using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Victory : MonoBehaviour
{
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
        _victoryPanel.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

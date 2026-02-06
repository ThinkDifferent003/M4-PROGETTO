using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Start : MonoBehaviour
{
    //SET
    [SerializeField] private string _sceneName = "Level";
    public void StartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(_sceneName);
    }
}

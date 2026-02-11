using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    //STATS
    [SerializeField] private int _maxHealth = 3;
    //UI REFERENCES
    [SerializeField] private UI_HealthBar _uiHealthBar;
    [SerializeField] private GameObject _gameOverPanel;
    //Audio
    [SerializeField] private AudioSource _music;
    //PRIVATE
    private int _currentHealth;
    private bool _isDead = false;
    void Start()
    {
        _currentHealth = 4;
        if (_uiHealthBar == null)
        {
            _uiHealthBar = FindAnyObjectByType<UI_HealthBar>();
        }

        UpdateHealthUI();

        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(false);
        }    
    }   
        
    public void TakeDamage(int damage)
    {
        if (_isDead) return;

        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        UpdateHealthUI();

        if(_currentHealth <= 0 )
        {
            Die();
        }
    }     
        
    public void AddHP(int amount)
    {
        _currentHealth += amount;
        
        _currentHealth = Mathf.Clamp(_currentHealth,0, _maxHealth);

        UpdateHealthUI();
    }

    public void InstantDie()
    {
        TakeDamage(_maxHealth);
    }

     private void Die()
    {
        _isDead = true;

        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(true);
        }

        if (_music != null)
        {
            _music.Stop();
        }

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Sei Morto");
    }

    private void UpdateHealthUI()
    {
        if (_uiHealthBar != null )
        {
            _uiHealthBar.UpdateUI(_currentHealth);
        }
    }

   

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        TakeDamage(1);
    //    }
    //}

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private UI_HealthBar _uiHealthBar;
    [SerializeField] private GameObject _gameOverPanel;

    private int _currentHealth;
    void Start()
    {
        _currentHealth = _maxHealth;
        if (_uiHealthBar != null )
        {
            _uiHealthBar.UpdateUI(_currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        if(_uiHealthBar != null )
        {
            _uiHealthBar.UpdateUI(_currentHealth);
        }
        if(_currentHealth <= 0 )
        {
            Die();
        }
    }

    public void AddHP(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        _uiHealthBar.UpdateUI( _currentHealth);
    }

    public void InstantDie()
    {
        TakeDamage(_maxHealth);
    }

    private void Die()
    {
        _gameOverPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
        }
    }
}

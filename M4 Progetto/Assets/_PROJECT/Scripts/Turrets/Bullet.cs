using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //SETT
    [SerializeField] private float _autoDestroy = 4f;
    [SerializeField] private float _speed = 20f;
    [SerializeField] private int _damage = 1;
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController _playerHP = other.GetComponent<PlayerHealthController>();

            if (_playerHP != null )
            {
                _playerHP.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }   
        
        
    

    private void Update()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }

    
}

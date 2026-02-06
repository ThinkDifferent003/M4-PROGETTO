using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Turret : MonoBehaviour
{
    //COMPONENTS
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected Transform _rotateHead;
    [SerializeField] protected GameObject _bulletPrefab;
    //STATS
    [SerializeField] protected float _fireRate = 1f;
    [SerializeField] protected float _rotationSpeed = 5f;
    //PRIVATE
    protected Transform _playerTransform;
    protected bool _isPlayerZone = false;
    protected float _nextFireTime = 0f;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            _playerTransform = player.transform;
        }
    }
    
    protected virtual void Update()
    {
        if (_playerTransform == null) return;

        CheckPlayer();

        if (_isPlayerZone)
        {
            Aim();
            if (Time.time >= _nextFireTime)
            {
                Shoot();
                _nextFireTime = Time.time + _fireRate;
            }
        }
        else
        {
            Routine();
        }
     }   
    
    protected virtual void Aim()
    {

    }

    protected virtual void CheckPlayer()
    {

    }
    
     protected virtual void Shoot()
    {
        if (_bulletPrefab != null && _firePoint != null)
        {
            Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        }
    }
    
    
    protected virtual void Routine()
    {

    }
   
}
    
    
    

    
    
    

        
   

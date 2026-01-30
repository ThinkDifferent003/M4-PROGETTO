using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Turret : MonoBehaviour
{
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected Transform _rotateHead;
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected float _fireRate = 1f;
    [SerializeField] protected float _rotationSpeed = 5f;
    [SerializeField] protected Transform _playerTransform;
    protected bool _isPlayerZone = false;
    protected float _nextFireTime = 0f;

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }
    protected virtual void Shoot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }

    
    protected virtual void Aim()
    {

    }

    protected virtual void Routine()
    {

    }

    protected virtual void CheckPlayer()
    {

    }
    
    protected virtual void Update()
    {
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
}
        
   

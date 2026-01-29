using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform _firePoint;
    [SerializeField] Transform _rotateHead;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private Transform _playerTransform;
    private bool _isPlayerZone = false;
    private float _nextFireTime = 0f;

    public void Shoot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerZone = false;
        }
    }
    void Update()
    {
        
        if (_isPlayerZone && _playerTransform != null)
        {
            Vector3 target = _playerTransform.position + Vector3.up * 1f;
            Vector3 direction = target - _firePoint.position;

            Quaternion rotation = Quaternion.LookRotation(direction);

            _rotateHead.rotation = Quaternion.Slerp(_rotateHead.rotation, rotation, Time.deltaTime * _rotationSpeed);

            if (Time.time >= _nextFireTime)
            {
                Shoot();
                _nextFireTime = Time.time + _fireRate;
            }
        }
        
    }
}

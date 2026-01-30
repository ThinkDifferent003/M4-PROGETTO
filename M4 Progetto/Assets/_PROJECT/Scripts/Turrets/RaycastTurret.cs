using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTurret : Turret
{
    [SerializeField] private float _distanceRay = 20f;
    [SerializeField] private LayerMask _obstacle;
    [SerializeField] private float _angleDegree = 45f;
    [SerializeField] private Light _turretLight;
    

    protected override void CheckPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, _firePoint.forward, out hit, _distanceRay, _obstacle))
        {
            if (hit.collider.CompareTag("Player"))
              {
                _isPlayerZone = hit.collider.CompareTag("Player");
              }
            else
              {
                _isPlayerZone = false;
              }
        }
        else
        {
            _isPlayerZone = false;
        }

        UpdateLight();
    }

    private void UpdateLight()
    {
        if (_turretLight == null) return;
        _turretLight.color = _isPlayerZone? Color.red : Color.green;
    }

    protected override void Routine()
    {
        float angle = Mathf.Lerp(-_angleDegree, _angleDegree, Mathf.PingPong(Time.time * _rotationSpeed,1));
        _rotateHead.localRotation = Quaternion.Euler(0, angle, 0);
    }

    private void LockTarget(Vector3 target)
    {
        Vector3 dir = target - _rotateHead.position;

        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            _rotateHead.rotation = Quaternion.Slerp(_rotateHead.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }

    protected override void Aim()
    {
        if (_playerTransform == null)
        {
            Vector3 targetPoint = _playerTransform.position + Vector3.up * 0.8f;
            LockTarget(targetPoint);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _isPlayerZone? Color.red : Color.green;
        Gizmos.DrawRay(_firePoint.position,_firePoint.forward * _distanceRay);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalTurret : Turret
{
    [SerializeField] private float _forceUp = 10f;
    [SerializeField] private float _launch = 5f;
    [SerializeField] private float _triggerRadius = 5f;
    [SerializeField] private Transform _point;

    protected override void CheckPlayer()
    {
        if (_point != null)
        {
            float distance = Vector3.Distance(_playerTransform.position, _point.position);
            _isPlayerZone = distance < _triggerRadius;
        }
    }

    protected override void Aim()
    {
        Vector3 direction = _playerTransform.position - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _rotateHead.rotation = Quaternion.Slerp(_rotateHead.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

        }
    }

    protected override void Shoot()
    {
        GameObject shell = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody rb = shell.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 launchDir = (_firePoint.forward * _launch) + (Vector3.up * _forceUp);
            rb.AddForce(launchDir , ForceMode.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        if (_point != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_point.position, _triggerRadius);
        }
    }
}

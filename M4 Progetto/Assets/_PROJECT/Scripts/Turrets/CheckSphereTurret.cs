using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSphereTurret : Turret
{
    //SETT
    [SerializeField] private LayerMask _layerPlayer;
    [SerializeField] private float _radius = 10f;
    protected override void CheckPlayer()
    {
        _isPlayerZone = Physics.CheckSphere(transform.position, _radius, _layerPlayer);
    }

    protected override void Aim()
    {
        if (_playerTransform != null)
        {
            Vector3 direction = _playerTransform.position - _rotateHead.position;

            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                _rotateHead.rotation = Quaternion.Slerp(_rotateHead.rotation, rotation, Time.deltaTime * _rotationSpeed);
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbital : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _mouseSensitivity = 100f;
    private float _distanceFromPlayer = 5f;

    [SerializeField] private LayerMask _obstacole;
    private float _currentDistance;
    private float _speed = 10f;

    private float _rotationX = 0f;
    private float _rotationY = 0f;
    
    [SerializeField] private Camera _camera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _camera.transform.localPosition = new Vector3(0,0, -_distanceFromPlayer);
    }

    private void LateUpdate()
    {
        if (Time.timeScale == 0f) return;

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _rotationY += mouseX;
        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -20f, 60f);

        transform.localRotation = Quaternion.Euler(_rotationX , _rotationY , 0f);
        transform.position = _player.position;

        Vector3 cameraPosition = transform.position - (transform.forward * _distanceFromPlayer);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.forward, out hit , _distanceFromPlayer, _obstacole))
        {
            _currentDistance = Mathf.Lerp(_currentDistance, hit.distance * 0.85f, _speed * Time.deltaTime);
        }
        else
        {
            _currentDistance = Mathf.Lerp(_currentDistance, _distanceFromPlayer, _speed * Time.deltaTime);

        }
        _camera.transform.localPosition = new Vector3(0, 0, - _currentDistance);
    }

}

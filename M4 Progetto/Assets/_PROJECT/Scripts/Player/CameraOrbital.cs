using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbital : MonoBehaviour
{
    //TARGET SET
    [SerializeField] private Transform _player;
    [SerializeField] private Camera _camera;
    //GENERAL SET
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private float _distanceFromPlayer = 5f;
    [SerializeField] private float _speed = 10f;
    //COLLISION
    [SerializeField] private LayerMask _obstacole;
    //PRIVATE
    private float _currentDistance;
    private float _rotationX = 0f;
    private float _rotationY = 0f;

    private void Awake()
    {
        if (_player == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null )
            {
                _player = player.transform;
            }
        }

        if (_camera == null)
        {
            _camera= GetComponentInChildren<Camera>();
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _currentDistance = _distanceFromPlayer;
        if (_camera != null)
        {
            _camera.transform.localPosition = new Vector3(0, 0, -_distanceFromPlayer);
        }
    }

    private void LateUpdate()
    {
        if (_player == null || Time.timeScale == 0f) return;

        Rotation();
        Collisions();
    }
        
     private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _rotationY += mouseX;
        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -20f, 60f);

        transform.localRotation = Quaternion.Euler(_rotationX, _rotationY, 0f);
        transform.position = _player.position;
    }    
   

    private void Collisions()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.forward, out hit, _distanceFromPlayer, _obstacole))
        {
            _currentDistance = Mathf.Lerp(_currentDistance, hit.distance * 0.85f, _speed * Time.deltaTime);
        }
        else
        {
            _currentDistance = Mathf.Lerp(_currentDistance, _distanceFromPlayer, _speed * Time.deltaTime);

        }
        _camera.transform.localPosition = new Vector3(0, 0, -_currentDistance);
    }

   

}

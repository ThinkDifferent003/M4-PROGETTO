using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbital : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _mouseSensitivity = 100f;
    private float _distanceFromPlayer = 5f;

    private float _rotationX = 0f;
    private float _rotationY = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Camera.main.transform.localPosition = new Vector3(0,0, -_distanceFromPlayer);
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _rotationY += mouseX;
        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -20f, 60f);

        transform.localRotation = Quaternion.Euler(_rotationX , _rotationY , 0f);
        transform.position = _player.position;
    }


    void Update()
    {
        
    }
}

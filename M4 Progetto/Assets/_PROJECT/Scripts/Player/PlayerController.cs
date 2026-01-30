using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    Rigidbody _rb;
    Vector2 _movement;

    [SerializeField] private float _jump;
    private bool _isGrounded;
    [SerializeField] Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.5f;
    [SerializeField] LayerMask _groundMask;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        _movement = new Vector2(moveX, moveY);

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        if (Input.GetButtonDown("Jump")  && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jump, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * _movement.y + right * _movement.x;


        _rb.MovePosition(_rb.position + moveDirection * (_speed * Time.fixedDeltaTime));

        
    }
}

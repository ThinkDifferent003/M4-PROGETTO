using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //MOVEMENT
    [SerializeField] private float _jump;
    [SerializeField] private float _speed;
    //GROUND CHECK
    [SerializeField] Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.5f;
    [SerializeField] LayerMask _groundMask;
    //PRIVATE
    private Vector2 _movement;
    private bool _isGrounded;
    private Rigidbody _rb;
    private Camera _camera;
    
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _camera = Camera.main;
        if (_camera == null)
        {
            _camera = FindAnyObjectByType<Camera>();
        }
        
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
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 forward = _camera.transform.forward;
        Vector3 right = _camera.transform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * _movement.y + right * _movement.x;

        if (moveDirection.magnitude > 0.1f)
        {
            moveDirection.Normalize();
        }


        _rb.MovePosition(_rb.position + moveDirection * (_speed * Time.fixedDeltaTime));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        ICollect obj = other.GetComponent<ICollect>();

        if (obj != null)
        {
            obj.Collect();
        }
    }

    
}

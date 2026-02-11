using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //WAYPOINT
    [SerializeField] private Transform _positionA;
    [SerializeField] private Transform _positionB;
    //STAT
    [SerializeField] private float _speed = 2f;
    //PRIVATE
    private Vector3 _previousPosition;
    private Vector3 _position;
    private Rigidbody _rbPlayer;
    void Start()
    {
        _position = _positionB.position;
        _previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _rbPlayer = other.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _rbPlayer = null;
        }
    }

    private void MoveElevator()
    {
        transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _position) < 0.1f)
        {
            if (_position == _positionA.position)
            {
                _position = _positionB.position;
            }
            else
            {
                _position = _positionA.position;
            }
        }
    }

    private void FixedUpdate()
    {
        MoveElevator();
        
        if ( _rbPlayer != null )
        {
            Vector3 platform = transform.position - _previousPosition;
            _rbPlayer.MovePosition(_rbPlayer.position + platform);
        }
        _previousPosition = transform.position;

    }
}

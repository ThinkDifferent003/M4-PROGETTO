using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;

    private void Update()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }
}

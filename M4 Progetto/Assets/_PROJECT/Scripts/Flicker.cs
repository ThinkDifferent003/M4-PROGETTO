using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private Light _light;
    [SerializeField] private float _minT = 0.5f;
    [SerializeField] private float _maxT = 5.0f;
    

    
    void Start()
    {
        _light = GetComponent<Light>();
        ChangeState();
    }

    private void ChangeState()
    {
        _light.enabled = !_light.enabled;
        float randomTime = Random.Range(_minT, _maxT);
        Invoke("ChangeState", randomTime);
    }
    
}

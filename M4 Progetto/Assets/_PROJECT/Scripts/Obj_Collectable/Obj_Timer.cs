using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Timer : MonoBehaviour , ICollect
{
    [SerializeField] private float _time = 15;

    public void Collect()
    {
        FindObjectOfType<UI_Timer>().AddTime(_time);
        Destroy(gameObject);
    }
}

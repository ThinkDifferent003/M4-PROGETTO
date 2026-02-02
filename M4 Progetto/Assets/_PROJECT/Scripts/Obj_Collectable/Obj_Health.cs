using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Health : MonoBehaviour , ICollect
{
    [SerializeField] private int _health = 1;
    public void Collect()
    {
        FindObjectOfType<PlayerHealthController>().AddHP(_health);
        Destroy(gameObject);
    }
}

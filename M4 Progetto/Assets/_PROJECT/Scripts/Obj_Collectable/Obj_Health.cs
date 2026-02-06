using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Health : MonoBehaviour , ICollect
{
    //STATS
    [SerializeField] private int _health = 1;
    public void Collect()
    {
        PlayerHealthController playerHP = FindAnyObjectByType<PlayerHealthController>();
        if (playerHP != null )
        {
            playerHP.AddHP( _health);
            Debug.Log($"Hai guadagnato {_health} punto salute!");
            Destroy(gameObject);
        }
    }
}

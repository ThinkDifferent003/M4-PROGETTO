using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Timer : MonoBehaviour , ICollect
{
    //STATS
    [SerializeField] private float _time = 15;

    public void Collect()
    {
        UI_Timer timer = FindAnyObjectByType<UI_Timer>();
        if (timer != null )
        {
            timer.AddTime( _time );
            Debug.Log($"Hai guadagnato {_time} secondi!");
            Destroy(gameObject);
        }
    }
}

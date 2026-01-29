using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
   protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController health = other.GetComponent<PlayerHealthController>();
            if (health != null)
            {
                OnPlayerEnter(health);
            }
        }
    }

    protected abstract void OnPlayerEnter(PlayerHealthController health);
}

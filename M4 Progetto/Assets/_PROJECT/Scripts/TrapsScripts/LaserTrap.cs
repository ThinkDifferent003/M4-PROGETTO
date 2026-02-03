using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : Trap
{
    protected override void OnPlayerEnter(PlayerHealthController health)
    {
        health.InstantDie();
    }
}

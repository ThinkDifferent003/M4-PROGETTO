using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap
{
    protected override void OnPlayerEnter(PlayerHealthController health)
    {
        health.InstantDie();
    }
}

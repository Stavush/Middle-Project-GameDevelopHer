using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public TrapModel[] traps;

    private void Start()
    {
        // initialize traps array by instantiating trap objects
    }

    public void ApplyTrapDamage(int index, IDamagable damagable)
    {
        if (index >= 0 && index < traps.Length)
        {
            traps[index].ApplyDamage(damagable);
        }
    }

}

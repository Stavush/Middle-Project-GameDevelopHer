using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Trap : MonoBehaviour, IDamagable
{
    public LayerMask whatIDamage;
    public abstract void ApplyDamage(IDamagable damagable);

    public void TakeDamage(int howMuch)
    {
        
    }


   public void Die()
    {
        Debug.Log("Player is dead!");
    }

}

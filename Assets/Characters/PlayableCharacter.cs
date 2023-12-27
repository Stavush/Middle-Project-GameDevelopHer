using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableCharacter : MonoBehaviour, IDamagable
{
    public int speed;
    public int maxHP;
    public int currentHP;

    public abstract void Movement();
    public abstract void ApplyDamage(IDamagable damagable);
    public abstract void SpecialAbility();

    public void TakeDamage(int howMuch)
    {
        currentHP -= howMuch;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player died!");
    }

}

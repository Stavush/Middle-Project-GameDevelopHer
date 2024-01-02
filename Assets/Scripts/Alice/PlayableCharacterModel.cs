using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacterModel : MonoBehaviour, IDamagable
{
    public int speed;
    public int maxHp;
    protected int currentHp;

    public virtual void Movement()
    {
        // Implement movement logic for the character
    }

    public virtual void ApplyDamage(IDamagable damagable)
    {
        // Implement how the character applies damage
    }

    public virtual void SpecialAbility()
    {
        // Implement special ability for the character
    }

    // Inheritance from IDamagable and implementation of it
    public void TakeDamage(int howMuch)
    {
        currentHp -= howMuch;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Implement player character death logic
    }
}

public class RegularAlice : PlayableCharacterModel
{
    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for regular Alice");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Apply damage for regular Alice");

    }

    public override void Movement()
    {
        //
    }
}

public class BigAlice : PlayableCharacterModel
{
    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for big Alice");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Apply damage for big Alice");

    }

    public override void Movement()
    {
        //
    }
}

public class LittleAlice : PlayableCharacterModel
{
    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for little Alice");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Apply damage for little Alice");

    }

    public override void Movement()
    {
        //
    }
}
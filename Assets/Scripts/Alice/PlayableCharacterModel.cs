using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableCharacterModel : MonoBehaviour, IDamagable
{
    public int speed;
    public int maxHp;
    protected int currentHp;

    public virtual void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }

    // abstract changes to virtual if we want all characters to act the same
    public abstract void ApplyDamage(IDamagable damagable); 

    public abstract void SpecialAbility();

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
        Debug.Log("Alice died :(");
    }
}
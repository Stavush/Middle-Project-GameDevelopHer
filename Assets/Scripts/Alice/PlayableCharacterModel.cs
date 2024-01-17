using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableCharacterModel : MonoBehaviour, IDamagable
{

    public int speed;
    public int maxHp = 3;
    public int currentHp;

    private bool isTurningRight = true;

    
    public virtual void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        if (horizontalInput > 0f && !isTurningRight)
        {
            FlipDirection();
        }
        else if(horizontalInput < 0f && isTurningRight)
        {
            FlipDirection();
        }

    }

    public void FlipDirection()
    {
        transform.Rotate(0f, 180f, 0f);
        isTurningRight = !isTurningRight;
    }

    // change abstract to virtual if we want all characters to act the same
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
        Debug.Log("Alice died :( ");
    }

    
}
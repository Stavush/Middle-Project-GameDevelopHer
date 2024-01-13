using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableCharacterModel : MonoBehaviour, IDamagable
{
    //public abstract int speed { get; set; }
    public int speed = 5;
    public int maxHp = 100;
    protected int currentHp;

    public virtual void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
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
        Debug.Log("Alice died :(");
    }
}
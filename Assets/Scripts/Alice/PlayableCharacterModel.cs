using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacterModel : MonoBehaviour, IDamagable
{

    public int speed;
    public int maxHp = 3;
    public int currentHp;

    public virtual void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }

    // change abstract to virtual if we want all characters to act the same
    public virtual void ApplyDamage(IDamagable damagable)
    {

    }

    public virtual void SpecialAbility()
    {

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
        Debug.Log("Alice died :( ");
    }

}
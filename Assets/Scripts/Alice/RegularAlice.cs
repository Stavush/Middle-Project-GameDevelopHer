using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularAlice : PlayableCharacterModel
{
    Rigidbody2D rb;
    private int jumpPower = 8;

    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for regular Alice");
    }

    public override void SpecialAbility()
    {
        // Special ability is jumping between spikes
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
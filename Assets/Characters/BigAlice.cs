using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Big alice has the ability to destroy the soldiers*/

public class BigAlice : PlayableCharacter
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

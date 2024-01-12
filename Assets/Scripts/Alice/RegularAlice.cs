using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularAlice : PlayableCharacterModel
{
 
    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for regular Alice");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Jump between spikes");

    }
}
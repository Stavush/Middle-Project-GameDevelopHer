using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularAlice : PlayableCharacterModel
{
    /*public override int speed
    {
        get { return speed; }
        set { speed = 5; }
    }*/

    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for regular Alice");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Jump between spikes");

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}

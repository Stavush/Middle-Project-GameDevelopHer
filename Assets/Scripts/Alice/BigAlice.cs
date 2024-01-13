using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAlice : PlayableCharacterModel
{
    /*public override int speed
    {
        get { return speed; }
        set { speed = value; }
    }*/

    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for big Alice");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Shoot particles at soldiers");

    }

}

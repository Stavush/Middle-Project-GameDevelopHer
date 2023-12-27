using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Little Alice has the ability to enter little passages*/ 

public class LittleAlice : PlayableCharacter
{

    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for little Alice");
    }
    
    public override void SpecialAbility()
    {
        Debug.Log("Apply special ability for regular Alice");
    }

    public override void Movement()
    {

    }
}

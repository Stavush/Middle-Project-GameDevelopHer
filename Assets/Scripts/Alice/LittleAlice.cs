using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleAlice : PlayableCharacterModel
{
    private bool isCrawling = false;

    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for little Alice");
    }

    public override void SpecialAbility()
    {
        // Special ability is crawling - only change animation and movement speed
        if (!isCrawling)
        {
            Debug.Log("She is crawling");
            isCrawling = true;
        }
        else
        {
            Debug.Log("She is not crawling");
            isCrawling = false;
        }
    }

    public bool IsCrawling()
    {
        return isCrawling;
    }


}

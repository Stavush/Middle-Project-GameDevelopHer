using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAlice : PlayableCharacterModel
{
    [SerializeField] public ParticleSystem particleSystem;

    [SerializeField] private AudioSource attackSoundEffect;

    public override void ApplyDamage(IDamagable damagable)
    {
        Debug.Log("Apply damage for big Alice");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Shoot particles at soldiers");
        particleSystem.Play();
        attackSoundEffect.Play();
    }

}

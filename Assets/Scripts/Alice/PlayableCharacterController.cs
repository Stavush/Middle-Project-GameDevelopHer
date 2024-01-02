using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacterController : MonoBehaviour
{
    private PlayableCharacterModel[] characters;
    private int currentCharacterIndex;

    private void Start()
    {
        // Initialize characters array with instantiated character objects
        currentCharacterIndex = 0; // Set the initial character
    }

    public void SwitchCharacter()
    {
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
    }

    public void ApplyCharacterDamage(IDamagable damagable)
    {
        characters[currentCharacterIndex].ApplyDamage(damagable);
    }

    public void MoveCurrentCharacter()
    {
        characters[currentCharacterIndex].Movement();
    }

    public void UseSpecialAbility()
    {
        characters[currentCharacterIndex].SpecialAbility();
    }
}


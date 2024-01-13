using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PlayableCharacterController : MonoBehaviour
{
    private CharacterSwitch switchPlayer;

    [SerializeField] private PlayableCharacterModel[] characters = new PlayableCharacterModel[3];
    private int currentCharacterIndex;


    private void Start()
    {
        switchPlayer = GetComponent<CharacterSwitch>();

        foreach (var character in characters)
        {
            character.currentHp = character.maxHp;
        }

        characters[0].speed = 5;
        characters[1].speed = 2;
        characters[2].speed = 3;

    }

    private void Update()
    {
        MoveCurrentCharacter();

        // Operate character's special ability when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseSpecialAbility();
        }

        // Switch a character when tab is pressed 
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter();  
        }

    }

    public void SwitchCharacter()
    {
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
        SetActiveCharacter(currentCharacterIndex);
    }

    public void SetActiveCharacter(int index)
    {
        switchPlayer.SwitchCharacter(currentCharacterIndex);
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


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayableCharacterController : MonoBehaviour
{
    private CharacterSwitch switchPlayer;

    [SerializeField] private PlayableCharacterModel[] characters = new PlayableCharacterModel[3];
    private int currentCharacterIndex;

    private void Start()
    {
        switchPlayer = GetComponent<CharacterSwitch>();

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
        Debug.Log("Enter to SwitchCharacter()");
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
        SetActiveCharacter(currentCharacterIndex);
    }

    public void SetActiveCharacter(int index)
    {
        Debug.Log("Enter to SetActiveCharacter()");
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


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayableCharacterController : MonoBehaviour
{
    [SerializeField] private PlayableCharacterModel[] characters = new PlayableCharacterModel[3];
    [SerializeField] private int currentCharacterIndex;

    private void Start()
    {
        // Initialize characters array with instantiated character objects
        currentCharacterIndex = 0; // Set the initial character (Regular Alice, 1= Big, 2 = Small)
        characters[0] = GetComponent<RegularAlice>();
        characters[1] = GetComponent<BigAlice>();
        characters[2] = GetComponent<LittleAlice>();
    }

    private void Update()
    {
        characters[currentCharacterIndex].Movement();

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

    private void SetActiveCharacter(int index)
    {
        // Disable all characters except the one at the given index
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].gameObject.SetActive(i == index);
        }
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


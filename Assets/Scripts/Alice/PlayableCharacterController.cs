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

        characters[0].speed = 3;
        characters[1].speed = 3;
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
        SwitchActiveChild(currentCharacterIndex);
    }

    public void SetActiveCharacter(int index)
    {
        switchPlayer.SwitchCharacter(currentCharacterIndex);
    }

    public void ApplyCharacterDamage(IDamagable damagable)
    {
        characters[currentCharacterIndex].ApplyDamage(damagable);
    }

    public void MoveCurrentCharacter() //Sarin changed it
    {
        //CencelBoxColiderForMovementToNotBeDisturbed(); // sarin added a function
        UpdateParentColliderFromActiveChild();
        //gameObject.GetComponent<PlayableCharacterModel>().speed = characters[currentCharacterIndex].speed;
        //gameObject.GetComponent<PlayableCharacterModel>().Movement();
    }

    public void UseSpecialAbility()
    {
        characters[currentCharacterIndex].SpecialAbility();
    }

    /*
    private void CencelBoxColiderForMovementToNotBeDisturbed() // and make sure they are moving together and not move around
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (currentCharacterIndex != i)
            {
                characters[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                characters[i].gameObject.transform.position = characters[currentCharacterIndex].gameObject.transform.position;
            }
            else if (currentCharacterIndex == i)
            {
                characters[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            }
            characters[i].transform.position = transform.position;
        }

    }
    */

    private void UpdateParentColliderFromActiveChild()
    {
        if (currentCharacterIndex >= 0 && currentCharacterIndex < characters.Length)
        {
            CapsuleCollider2D activeChildCollider = characters[currentCharacterIndex].gameObject.GetComponent<CapsuleCollider2D>();
            CapsuleCollider2D parentCollider = GetComponent<CapsuleCollider2D>();

            if (activeChildCollider != null && parentCollider != null)
            {
                // Copy the size and offset of the active child's capsule collider to the parent
                parentCollider.size = activeChildCollider.size;
                parentCollider.offset = activeChildCollider.offset;
            }
        }
    }

    // Call this function whenever you switch the active child
    private void SwitchActiveChild(int newIndex)
    {
        currentCharacterIndex = newIndex;
        UpdateParentColliderFromActiveChild();
    }



}

/*public class PlayableCharacterController : MonoBehaviour
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
}*/


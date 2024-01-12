using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayableCharacterController : MonoBehaviour
{
    [SerializeField] private PlayableCharacterModel[] characters = new PlayableCharacterModel[3];
    private int currentCharacterIndex;

    private void Start()
    {
        // Initialize characters array with instantiated character objects
        currentCharacterIndex = 0; // Set the initial character 0 = Regular Alice, 1 = Big, 2 = Small)
        characters[0] = gameObject.AddComponent<RegularAlice>();
        characters[1] = gameObject.AddComponent<BigAlice>();
        characters[2] = gameObject.AddComponent<LittleAlice>();

        Debug.Log("length =" + characters.Length);
        Debug.Log("CurrentIndex: " + currentCharacterIndex);
        SetActiveCharacter(currentCharacterIndex);
    }

    private void Update()
    {
        MoveCurrentCharacter();

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
        Debug.Log("CurrentIdx: " + currentCharacterIndex);
        SetActiveCharacter(currentCharacterIndex);
    }

    public void SetActiveCharacter(int index)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].gameObject.SetActive(i == index);
            Debug.Log(i + " active? "+characters[i].gameObject.activeInHierarchy);
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


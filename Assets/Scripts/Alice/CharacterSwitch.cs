
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterSwitch : MonoBehaviour
{
    PlayableCharacterModel[] characters;

    public GameObject RegularAlice;
    public GameObject BigAlice;
    public GameObject LittleAlice;


    void Start()
    {
        characters = new PlayableCharacterModel[3];

        characters[0] = RegularAlice.GetComponent<RegularAlice>();
        characters[1] = BigAlice.GetComponent<BigAlice>();
        characters[2] = LittleAlice.GetComponent<LittleAlice>();


        RegularAlice.SetActive(true);
        BigAlice.SetActive(false);
        LittleAlice.SetActive(false);
    }

    public void SwitchCharacter(int index)
    {
        Debug.Log("Enter to SwitchCharacter() in CharacterSwitch");

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != null)
            {
                characters[i].gameObject.SetActive(i == index);
                Debug.Log(i + " active? " + characters[i].gameObject.activeInHierarchy);
            }
            else
            { 
                Debug.Log(i + " is null");
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayableCharacterModel character;
    [SerializeField] private UnityEngine.UI.Image totalHpBar;
    [SerializeField] private UnityEngine.UI.Image currentHpBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHpBar = GetComponent<Image>();
        UpdateHealthBar();
        //totalHpBar.fillAmount = character.currentHp / 10;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        
    }

    private void UpdateHealthBar()
    {

        if (character)
        {
            float fillAmount = (float)character.currentHp / character.maxHp;
            currentHpBar.fillAmount = fillAmount;
        }
    }

}

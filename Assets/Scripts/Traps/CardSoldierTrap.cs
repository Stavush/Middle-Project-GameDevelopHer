using UnityEngine;

public class CardSoldierTrap : BaseTrap
{
    public override void TriggerTrap(GameObject player)
    {
        // Additional logic specific to CardSoldierTrap
        if (player.CompareTag("MediumAlice"))
        {
            // Medium Alice can blow away the card soldier with a kiss
            Debug.Log("Medium Alice blew away the card soldier with a kiss!");
        }
        else
        {
            // Deal damage to the wrong character
            DealDamage(damageAmount);
        }
    }
}
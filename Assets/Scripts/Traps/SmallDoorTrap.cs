using UnityEngine;

public class SmallDoorTrap : BaseTrap
{
    public override void TriggerTrap(GameObject player)
    {
        // Additional logic specific to SmallDoorTrap
        if (player.CompareTag("SmallAlice"))
        {
            // Only small Alice can go through the door
            Debug.Log("Small Alice passed through the door!");
        }
        else
        {
            
            TakeDamage(damageAmount);
        }
    }
}
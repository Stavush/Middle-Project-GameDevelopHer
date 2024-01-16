using UnityEngine;

public class RoseSpikesTrap : BaseTrap
{
    public override void TriggerTrap(GameObject player)
    {
        // Additional logic specific to RoseSpikesTrap
        if (player.CompareTag("BigAlice"))
        {
            // Only big Alice can walk on rose spikes
            Debug.Log("Big Alice walked on the rose spikes!");
        }
        else
        {
            // Deal damage to the wrong character
            TakeDamage(damageAmount);
        }
    }
}
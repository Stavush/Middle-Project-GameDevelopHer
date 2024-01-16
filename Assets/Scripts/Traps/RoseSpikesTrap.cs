using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class RoseSpikesTrap : BaseTrap
{
    [SerializeField]
    public GameObject Player;
    IDamagable d;
    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("BigAlice") && Input.GetKeyDown(KeyCode.Space))
        {
            // Only big Alice can walk on rose spikes
            Debug.Log("Big Alice walked on the rose spikes!");
        }
        else
        {
            Player.GetComponent<PlayableCharacterController>().ApplyCharacterDamage(d);

            TakeDamage(damageAmount);
        }
    }

}
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class RoseSpikesTrap : BaseTrap
{
    [SerializeField]
    public GameObject Player;
    IDamagable d;
    bool hasDestroyed = false;
    [SerializeField]Sprite destroyedSpikesSprite;
    public void OnTriggerEnter2D(Collider2D c)
    {/*
        if (isDestroyed == false)
        {
            if (c.gameObject.CompareTag("RegularAlice") && Input.GetKey(KeyCode.Space) && c.gameObject.activeSelf)
            {
                // Only big Alice can walk on rose spikes
                Debug.Log("Regular Alice walked on the rose spikes!");
                //change animation
                DestroySpike();
            }
            else if (c.gameObject.activeSelf)
            {
                Player.GetComponent<PlayableCharacterController>().ApplyCharacterDamage(d);

               // c.gameObject.GetComponent<PlayableCharacterModel>().TakeDamage(damageAmount);

            }
        }
        */

        if (c.gameObject.active && c.gameObject.CompareTag("RegularAlice") && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Regular Alice passed the spikes!");

            //change animation
            DestroySpike();
        }
        else if(c.gameObject.active && (c.gameObject.CompareTag("BigAlice") || c.gameObject.CompareTag("LittleAlice")|| c.gameObject.CompareTag("RegularAlice")))
        {
            Debug.Log(c.gameObject.name + " got damage");
        }
    }

    private void DestroySpike()
    {
        if(hasDestroyed == false)
        {
            //change sprite to destroyed sprite??
            gameObject.GetComponent<SpriteRenderer>().sprite = destroyedSpikesSprite;

        Debug.Log("spikes are destroyed");
        hasDestroyed = true;
        }
    }

}
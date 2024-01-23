using UnityEngine;

public class SmallDoorTrap : BaseTrap

{
    [SerializeField]
    //public GameObject Player
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("LittleAlice"))
        {
            if(collision.gameObject.GetComponent<LittleAlice>().IsCrawling() == true)
            {
                // Only small Alice can go through the door

                Debug.Log("Small Alice can pass through the door!");

                BoxCollider2D doorCollider = GetComponent<BoxCollider2D>();

                    if (doorCollider != null)
                    {
                        doorCollider.enabled = false;
                    Invoke("TurnOnAgainTheBoxCollider", 3f);
                 
                    }

            }
            else
            {
            Debug.Log(collision.gameObject.name + " take damage from door");
            }
        }
        else
        {
            //TakeDamage(damageAmount);
            Debug.Log(collision.gameObject.name + " take damage from door");
        }
    }

    private void TurnOnAgainTheBoxCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
using UnityEngine;

public class CardSoldierTrap : BaseTrap
{

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamage(damageAmount);
        }
        if (collision.gameObject.CompareTag("Heart"))
        {
           TakeDamage(damageAmount);
        
            // Medium Alice can blow away the card soldier with a kiss
            Debug.Log("Medium Alice blew away the card soldier with a kiss!");
        }
     
    }
}
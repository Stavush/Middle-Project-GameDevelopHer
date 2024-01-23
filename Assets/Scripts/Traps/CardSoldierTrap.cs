using UnityEngine;

public class CardSoldierTrap : BaseTrap
{
    private bool IsDead = false;
    [SerializeField]Sprite deadSoilderSprite;
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if(IsDead == false)
            {
                if ((collision.gameObject.CompareTag("BigAlice") || collision.gameObject.CompareTag("LittleAlice") || collision.gameObject.CompareTag("RegularAlice"))&& collision.gameObject.active)
                {
                    //DealDamage(damageAmount);
                    // sarin: i dont know what it doese aaaa
                    Debug.Log(collision.gameObject.name +  " got hurt by soilder");
                }


                if (collision.gameObject.CompareTag("Heart"))
                {
                    //TakeDamage(damageAmount);

                    Debug.Log("Big Alice blew away the card soldier with a kiss!");
                        IsDead = true;

                     gameObject.GetComponent<SpriteRenderer>().sprite = deadSoilderSprite;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

            }
        }

    }
}

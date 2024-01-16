using UnityEngine;

public class SmallDoorTrap : BaseTrap

{
    [SerializeField]
    public GameObject Player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("SmallAlice")&& Input.GetKey(KeyCode.Space))
        {
            // Only small Alice can go through the door
            Debug.Log("Small Alice passed through the door!");

            BoxCollider2D doorCollider = GetComponent<BoxCollider2D>();
            if (doorCollider != null)
            {
                doorCollider.enabled = false;
            }
        }
        else
        {
            TakeDamage(damageAmount);
        }
    }
}
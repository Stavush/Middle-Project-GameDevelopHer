using UnityEngine;

public class BaseTrap : MonoBehaviour, IDamagable
{

    public int damageAmount = 10;

    public virtual void TriggerTrap(GameObject player)
    {
        Debug.Log("Trap triggered!");
    }

    public virtual void TakeDamage(int howMuch)
    {
        Debug.Log($"{gameObject.name} took {howMuch} damage.");
    }

    public virtual void DealDamage(int Damage)
    {

        Debug.Log($"{gameObject.name} did {Damage} damage.");
    }


    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} died");
    }
}
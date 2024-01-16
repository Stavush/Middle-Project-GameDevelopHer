using UnityEngine;

public interface IDamagable
{
    void TakeDamage(int howMuch);
    void DealDamage(int Damage);
    void Die();
}